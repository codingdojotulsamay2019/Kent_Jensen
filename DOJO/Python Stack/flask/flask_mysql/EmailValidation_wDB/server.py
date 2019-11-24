from flask import Flask, request, redirect, render_template, session, flash
from MySQLConnection import connectToMySQL    # import the function that will return an instance of a connection
app = Flask(__name__)
app.secret_key= "keep it secret, keep it safe"

import re   # the regex module
# create a regular expression object that we'll use later
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')


# table in EmailValidation_wDB is called "checked_email" with "email" column, also created_at and updated_at (auto fill NOW()). 
# flash("Email cannot be blank!", 'email')         <--- used to categorize flash messages.

@app.route('/') #root route
def index():
    mysql = connectToMySQL('EmailValidation_wDB')
    return render_template("index.html")

@app.route('/', methods = ['POST']) #AVOID INJECTION, sends email to database after validation
def validate ():
    if not EMAIL_REGEX.match(request.form['email']):    # test whether a field matches the pattern
        flash("Invalid email address!")
        return redirect('/')
    mysql = connectToMySQL('EmailValidation_wDB')
    query = "INSERT INTO checked_email (email) VALUES(%(em)s);"
    data = {
        'em' : request.form['email']
    }
    validate = mysql.query_db(query,data)
    print("*"*80)
    print("You're being redirected to SUCCESS")
    print("*"*80)
    session['success']=True
    return redirect('/success')

@app.route('/success') #shows table of database entries
def success():
    mysql = connectToMySQL('EmailValidation_wDB')
    query = "SELECT id, email, created_at FROM checked_email;"
    print("*"*80)
    print("RENDERING SUCCESS")
    print("*"*80)
    success = mysql.query_db(query)
    if(session['success'] == False) or ("success" not in session):
        session['success'] = False
    else:
        last_email = success[len(success)-1]['email']
        flash("The email address you entered " + last_email + " is a valid email address! Thank you!",'email')
        session['success']=False
    return render_template("success.html", checked_email=success)

@app.route('/delete/<id>')
def destroy(id):
    print("*"*80)
    mysql = connectToMySQL('EmailValidation_wDB')
    query = "DELETE FROM checked_email WHERE id = %(id)s;"
    data = {
        "id" : id
    }
    print("*"*80)
    print("DELETING EMAIL")
    print("*"*80)
    delete = mysql.query_db(query,data)
    return redirect('/success')
if __name__=="__main__":
    app.run(debug=True)