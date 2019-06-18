from flask import Flask, request, redirect, render_template, session, flash
from MySQLConnection import connectToMySQL    # import the function that will return an instance of a connection
app = Flask(__name__)
app.secret_key= "keep it secret, keep it safe"
import hashlib
import os, binascii
import re   # the regex module
# create a regular expression object that we'll use later

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

from flask_bcrypt import Bcrypt        
bcrypt = Bcrypt(app)     # we are creating an object called bcrypt, 
                         # which is made by invoking the function Bcrypt with our app as an argument

# table in LoginReg is called "users" with "first_name", "last_name", "email", "hash" and "salt" columns, also "created_at" and "updated_at" (auto fill NOW()). 



@app.route('/') #root route to index page
def index():
    mysql = connectToMySQL('LoginReg')
    return render_template("index.html")

@app.route('/register', methods = ['POST']) #Register route - AVOID INJECTION, sends email to database after validation
def validate ():
    mysql = connectToMySQL('LoginReg')
    password_string=request.form['password']
    hashed_password="SELECT hashed_password FROM users WHERE id = %(id)s"
    if not EMAIL_REGEX.match(request.form['email']):    # test whether a field matches the pattern
        flash("Invalid email address!", 'email')
        return redirect('/')
    # len(first_name) > 1, len(last_name) > 1, email doesn't exist on server, and password === pwverify VALIDATIONS GO HERE.
    is_valid = True
    if len(request.form['first_name']) < 2:
    	is_valid = False
    	flash("Please enter a first name.", 'first_name')
    if len(request.form['last_name']) < 2:
    	is_valid = False
    	flash("Please enter a last name.", 'last_name')
    if len(request.form['password']) < 7:
    	is_valid = False
    	flash("Password should be at least 8 characters long.", 'password')
    if request.form['password'] != request.form['pwverify']:
        is_valid = False
        flash("Password and password verification fields must match exactly.",'password2')

    match = re.match(r'^[A-Za-z ]*$', request.form['first_name'])
    match = re.match(r'^[A-Za-z ]*$', request.form['last_name'])
    if not match :
        flash("Invalid characters in name. Standard alphabet A-Z and a-z accepted.", 'name')
        is_valid = False
    if not is_valid:
        return redirect("/")
    else:
    	# add user to database
        mysql = connectToMySQL('LoginReg')
        pw_hash = bcrypt.generate_password_hash(request.form['password'])
        query = "INSERT INTO users (first_name, last_name, email, hashed_password) VALUES (%(fn)s, %(ln)s, %(em)s, %(hpw)s);" #DON'T FORGET PASSWORD HASH!
        data = {
            'fn' : request.form['first_name'],
            'ln' : request.form['last_name'],
            'em' : request.form['email'],
            'hpw' : pw_hash
        }
        validate = mysql.query_db(query,data)
    print("*"*80)
    print("You're being redirected to SUCCESS")
    print("*"*80)
    session['logged_in']=True
    return redirect('/success')
# ********************



#     # see if the username provided exists in the database
#     mysql = connectToMySQL("mydb")
#     query = "SELECT * FROM users WHERE username = %(username)s;"
#     data = { "username" : request.form["username"] }
#     result = mysql.query_db(query, data)
#     if len(result) > 0:
#         # assuming we only have one user with this username, the user would be first in the list we get back
#         # of course, we should have some logic to prevent duplicates of usernames when we create users
#         # use bcrypt's check_password_hash method, passing the hash from our database and the password from the form
#         if bcrypt.check_password_hash(result[0]['password'], request.form['password']):
#             # if we get True after checking the password, we may put the user id in session
#             session['userid'] = result[0]['id']
#             # never render on a post, always redirect!
#             return redirect('/success')
#     # if we didn't find anything in the database by searching by username or if the passwords don't match,
#     # flash an error message and redirect back to a safe route
#     flash("You could not be logged in")
#     return redirect("/")




# ********************

@app.route('/login', methods = ['POST']) #Login route - AVOID INJECTION, sends email to database after validation
def login():
    mysql = connectToMySQL("LoginReg")
    query = "SELECT * FROM users WHERE email = %(email)s;"
    data = { "email" : request.form["email_login"] }
    result = mysql.query_db(query, data)
    if len(result) > 0:
        if bcrypt.check_password_hash(result[0]['hashed_password'], request.form['password_login']):
            session['userid'] = result[0]['id']
            session['logged_in']=True
            return redirect('/success')
    print("*"*80)
    print("You're being redirected to SUCCESS")
    print("*"*80)
    flash("You could not be logged in", 'failure')
    session['logged_in']=False
    return redirect("/")

@app.route('/success') #MUST BE LOGGED IN TO SEE THIS SITE. shows success page with logout button.
def success():
    if(session['logged_in'] == False) or ("logged_in" not in session):
        return redirect('/')
    else:
        session['logged_in']=True
        return render_template("success.html")

@app.route('/logout') #handles logout button and deletes session
def logout():
    session['logged_in']=False
    return redirect('/')

if __name__=="__main__":
    app.run(debug=True)