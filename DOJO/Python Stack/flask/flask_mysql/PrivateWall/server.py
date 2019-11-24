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

# first table in PrivateWall is called "users" with "first_name", "last_name", "email", "hashed_password" columns, also "created_at" and "updated_at" (auto fill NOW()). 
# second table in PrivateWall is called "messages" with "content", "recip_id", "sender_id", "created_at"


@app.route('/') #root route to index page
def index():
    mysql = connectToMySQL('PrivateWall')
    return render_template("index.html")

@app.route('/register', methods = ['POST']) #Register route - AVOID INJECTION, sends email to database after validation
def validate ():
    mysql = connectToMySQL('PrivateWall')
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
        mysql = connectToMySQL('PrivateWall')
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

@app.route('/login', methods = ['POST']) #Login route - AVOID INJECTION, sends email to database after validation
def login():
    mysql = connectToMySQL("PrivateWall")
    query = "SELECT * FROM users WHERE email = %(email)s;"
    data = { "email" : request.form["email_login"] }
    result = mysql.query_db(query, data)
    if len(result) > 0:
        if bcrypt.check_password_hash(result[0]['hashed_password'], request.form['password_login']):
            session['userid'] = result[0]['id']
            session['logged_in']=True
            session['user_name']=result[0]['first_name']
            return redirect('/success')
    print("*"*80)
    print("You're being redirected to SUCCESS")
    print("*"*80)
    flash("You could not be logged in", 'failure')
    session['logged_in']=False
    return redirect("/")

@app.route('/success') #MUST BE LOGGED IN TO SEE THIS SITE. shows success page with logout button.
def success():
    mysql = connectToMySQL("PrivateWall")
    get_names = mysql.query_db("SELECT id, first_name FROM users")
    mysql = connectToMySQL("PrivateWall")
    get_messages = mysql.query_db("SELECT messages.id, messages.content, messages.sender_id, messages.recip_id, messages.created_at, users.first_name FROM messages JOIN users ON messages.sender_id = users.id")
    if(session['logged_in'] == False) or ("logged_in" not in session):
        return redirect('/')
    else:
        session['logged_in']=True
        return render_template("success.html", messages = get_messages, users = get_names)

@app.route('/logout') #logout button and resets logged_in to false
def logout():
    session['logged_in']=False
    return redirect('/')

@app.route('/delete_message/<msgid>') #deletes message, but only if userid in session = recip_id on message.
def delete(msgid):
    print(msgid)
    mysql = connectToMySQL("PrivateWall")
    query = "DELETE FROM messages WHERE messages.id = %(msg_id)s;"
    data = {
        'msg_id' : msgid
    }
    delete_msg=mysql.query_db(query,data)
    return redirect('/success')

@app.route('/send_message', methods=["POST"])
def send_message():
    mysql = connectToMySQL("PrivateWall")
    store = session['userid']
    query = "INSERT INTO messages (content, recip_id, sender_id) VALUES (%(form)s, %(recip_id)s, %(sender_id)s);"
    data = {
        'form' : request.form['content'],
        'recip_id' : request.form['recip'],
        'sender_id' : store
    }
    send_message= mysql.query_db(query,data)
    return redirect('/success')
if __name__=="__main__":
    app.run(debug=True)