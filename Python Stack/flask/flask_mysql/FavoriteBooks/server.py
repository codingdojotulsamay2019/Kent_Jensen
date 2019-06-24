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

# table in FavoriteBooks is called "users" with "first_name", "last_name", "email", "hashed_password" columns, also "created_at" and "updated_at" (auto fill NOW()). 
# table in FavoriteBooks is called "books" with "title", "desc", and "uploaded_by_id" as well as created_at/updated_at.
# table in FavoriteBooks is called "favorites" with "book_id" and "user_id"


@app.route('/') #root route to index page
def index():
    mysql = connectToMySQL('FavoriteBooks')
    return render_template("index.html")

# !!!! Need to fix validations here, check notebook. !!!!
@app.route('/register', methods = ['POST']) #Register route - AVOID INJECTION, sends email to database after validation
def validate ():
    is_valid = True #sets is_valid to False, must be True/not False to login
    mysql = connectToMySQL('FavoriteBooks')
    mysql.query_db="SELECT hashed_password FROM users WHERE id = %(id)s"
    if not EMAIL_REGEX.match(request.form['email']):    # test whether a email matches the REGEX pattern
        flash("Invalid email address!", 'email')
        print("Invalid input - registered email address")
        return redirect('/')

    mysql = connectToMySQL('FavoriteBooks')
    check = mysql.query_db("SELECT email FROM users")
    if(request.form['email'] in check): #tests if email is already in database.
        flash("Email already registered. Please log in.", 'register_email')
        print("Email already registered. Please login.")
        is_valid = False

    if len(request.form['first_name']) < 2: #tests if first name is longer than 2 characters.
        flash("Please enter a first name.", 'first_name')
        print("Invalid input - registered first name too short.")
        is_valid = False

    if len(request.form['last_name']) < 2: #tests if last name is longer than 2 characters
        flash("Please enter a last name.", 'last_name')
        print("Invalid input - registered last name too short")
        is_valid = False

    if len(request.form['password']) < 7: #tests if password is longer than 7 characters.
        flash("Password should be at least 8 characters long.", 'password')
        print("Invalid input - registered password too short")
        is_valid = False

    if request.form['password'] != request.form['pwverify']: # tests if password is equal to pwverify
        flash("Password and password verification fields must match exactly.",'password_match')
        print("Invalid input - registered password verification doesn't match password")
        is_valid = False

    match = re.match(r'^[A-Za-z ]*$', request.form['first_name']) #tests first name against REGEX
    if not match :
        flash("Invalid characters in first name. Standard alphabet A-Z and a-z accepted.", 'first_name')
        print("Invalid input - registered first name has invalid characters")
        is_valid = False

    match = re.match(r'^[A-Za-z ]*$', request.form['last_name']) #tets last name against REGEX 
    if not match :
        flash("Invalid characters in last name. Standard alphabet A-Z and a-z accepted.", 'last_name')
        print("Invalid input - registered last name has invalid characters")
        is_valid = False

    #Go/No Go Line
    if is_valid == False: #if is_valid is false, redirects to home pg
        flash("Unable to register account.")
        return redirect("/")
    else:
        # add user to database
        print("starting add user process")
        mysql = connectToMySQL('FavoriteBooks')
        pw_hash = bcrypt.generate_password_hash(request.form['password'])
        query = "INSERT INTO users (first_name, last_name, email, hashed_password) VALUES (%(fn)s, %(ln)s, %(em)s, %(hpw)s);" #DON'T FORGET PASSWORD HASH!
        data = {
            'fn' : request.form['first_name'],
            'ln' : request.form['last_name'],
            'em' : request.form['email'],
            'hpw' : pw_hash
        }
        validate = mysql.query_db(query,data)
        mysql = connectToMySQL('FavoriteBooks')
        query2="SELECT id FROM users where email = %(em)s;"
        data2 = {
            'em' : request.form['email']
        }
        result=mysql.query_db(query2, data2)
        session['logged_in']=True
        print(result)
        session['user_id'] = result[0]['id']
        print("*"*80)
        print("Add user successful.")
        print("You're being redirected to SUCCESS.")
        print("*"*80)
        return redirect('/success')

@app.route('/login', methods = ['POST']) #Login route - AVOID INJECTION, sends email to database after validation
def login():
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT id, email, hashed_password FROM users WHERE email = %(email)s;"
    data = { "email" : request.form["email_login"] }
    result = mysql.query_db(query, data)
    if len(request.form['password_login']) > 0:
        if bcrypt.check_password_hash(result[0]['hashed_password'], request.form['password_login']):
            session['user_id'] = result[0]['id']
            session['logged_in']=True
            print("*"*80)
            print("You're being redirected to SUCCESS")
            print("*"*80)
            return redirect('/success')
        else:
            flash("You could not be logged in", 'failure')
            print("You could not be logged in")
            return redirect("/")
    else:
        flash("Password must be filled in.", 'login_password')
        print("Password must be filled in.")
        return redirect("/")

@app.route('/success') #MUST BE LOGGED IN TO SEE THIS SITE. shows success page with logout button.
def success():
    if("logged_in" not in session) or ("user_id" not in session) or (session['logged_in'] == False):
        flash("You do not have permission to view that site without being logged in.", 'failure')
        print("no permission to view site")
        return redirect('/')
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT first_name FROM users WHERE id = %(id)s;"
    data = {
        'id' : session['user_id']
    }
    firstname = mysql.query_db(query, data)
    print(firstname)
    print("*****Success!*****")
    return render_template("success.html", name=firstname)

#add Book route
@app.route('/addbook')
def add_book():
    #need validations for title/description. uploaded_by_id should get set based on session
    if(len(request.form['title']) < 0):
        is_valid = False
    if(len(request.form['desc']) < 5):
        is_valid = False
    
    query = "INSERT INTO books (title, desc, uploaded_by_id) VALUES ( %(title)s, %(desc), %(uid);)"
    data = {
        'title' : request.form['title'],
        'desc' : request.form['desc'],
        'uid' : session['user_id']
    }
    return redirect('/success')

@app.route('/editbook/<id>')
def edit_book(id):
    #validate for user_id in session vs uploaded_by_id
    connectToMySQL=('FavoriteBooks')
    query="SELECT uploaded_by_id FROM books WHERE id = %(id)s;"
    data = {
        'id' : id
    }
    bookid = mysql.query_db(query,data)
    if(session['user_id'] != bookid['uploaded_by_id']):
        session['admin']=False
        return redirect('/success')
    if(session['user_id'] == bookid['uploaded_by_id']):
        session['admin']=True
    connectToMySQL=('FavoriteBooks')
    query = "UPDATE books SET title = 'request.form['title']', desc = 'request.form['desc']' WHERE id = %(id)s;"
    data = {
        'id' : id
    }
    update_book= mysql.query_db(query, data)
    return redirect('/success',id=update_book)


#edit Book route - requires added_by_id

@app.route('/logout') #handles logout button and deletes session
def logout():
    session.clear()
    return redirect('/')

if __name__=="__main__":
    app.run(debug=True)