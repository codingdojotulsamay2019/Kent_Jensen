from flask import Flask, request, redirect, render_template, session, flash
from MySQLConnection import connectToMySQL    # import the function that will return an instance of a connection
app = Flask(__name__)
app.secret_key= "keep it secret, keep it safe"
import hashlib
import os, binascii
import re


EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

from flask_bcrypt import Bcrypt
bcrypt = Bcrypt(app)

@app.route('/') #root route to index page
def index():
    mysql = connectToMySQL('FavoriteBooks')
    return render_template("index.html")

@app.route('/register', methods = ['POST']) #Register route - AVOID INJECTION, sends email to database after validation
def validate ():
    mysql = connectToMySQL('FavoriteBooks')# query for if email is already in database.
    query = "SELECT email FROM users"
    check_email = mysql.query_db(query)
    mysql = connectToMySQL('FavoriteBooks')# query for if email is already in database.
    query = "SELECT password FROM users"
    check_password = mysql.query_db(query)
    is_valid = True #sets is_valid to True, must be True/not False to login
    match = re.match(r'^[A-Za-z ]*$', request.form['first_name']) #tests first name against REGEX
    if not match :
        flash("Invalid characters in first name. Standard alphabet A-Z and a-z accepted.", 'first_name')
        print("Invalid input - registered first name has invalid characters")
        is_valid = False

    match = re.match(r'^[A-Za-z ]*$', request.form['last_name']) #tests last name against REGEX 
    if not match :
        flash("Invalid characters in last name. Standard alphabet A-Z and a-z accepted.", 'last_name')
        print("Invalid input - registered last name has invalid characters")
        is_valid = False
    if len(request.form['first_name']) < 1: #tests if first name is longer than 2 characters.
        flash("Please enter a first name.", 'first_name')
        print("Invalid input - registered first name too short.")
        is_valid = False

    if len(request.form['last_name']) < 1: #tests if last name is longer than 2 characters
        flash("Please enter a last name.", 'last_name')
        print("Invalid input - registered last name too short")
        is_valid = False

    if not EMAIL_REGEX.match(request.form['email_reg']):    # test whether a email matches the REGEX pattern
        flash("Invalid email address!", 'email')
        print("Invalid input - registered email address")
        return redirect('/')

    print("*"*80)
    print("*"*80)
    print("*"*80)
    print(check_email)
    print(request.form['email_reg'])
    for email in check_email:
        if request.form['email_reg'] in check_email:
            is_valid = False
            flash("Email already registered. Please log in instead.", 'register_email')
            print("Email already registered. Please log in instead.")
            return redirect ('/')

    if len(request.form['password']) < 7:
        flash("Password should be at least 8 characters long.", 'password')
        print("Invalid input - registered password too short")
        is_valid = False

    if request.form['password'] != request.form['pwverify']: # tests if password is equal to pwverify
        flash("Password and password verification fields must match exactly.",'password_match')
        print("Invalid input - registered password verification doesn't match password")
        is_valid = False

    #Go/No Go Line
    if is_valid == False: 
        flash("Unable to register account.")
        return redirect("/")
    else:
        # add user to database
        print("starting add user process")
        mysql = connectToMySQL('FavoriteBooks')
        pw_hash = bcrypt.generate_password_hash(request.form['password'])
        query = "INSERT INTO users (first_name, last_name, email, password) VALUES (%(fn)s, %(ln)s, %(em)s, %(hpw)s);" 
        data = {
            'fn' : request.form['first_name'],
            'ln' : request.form['last_name'],
            'em' : request.form['email_reg'],
            'hpw' : pw_hash
        }
        validate = mysql.query_db(query, data)
        mysql = connectToMySQL('FavoriteBooks')
        query2="SELECT id FROM users where email = %(em)s;"
        data2 = {
            'em' : request.form['email_reg']
        }
        result=mysql.query_db(query2, data2)
        session['logged_in']=True
        print(result)
        session['user_id'] = result[0]['id']
        print("*"*80)
        print(check_email)
        print("Add user successful.")
        print("You're being redirected to SUCCESS.")
        print("*"*80)
        return redirect('/success')

@app.route('/login', methods = ['POST']) 
def login():
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT id, email, password FROM users WHERE email = %(email)s;"
    data = { "email" : request.form["email_login"] }
    result = mysql.query_db(query, data)
    if len(request.form['password_login']) and len(request.form['email_login']) > 0:
        if bcrypt.check_password_hash(result[0]['password'], request.form['password_login']):
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
        flash("Email and password must be filled in.", 'login_password')
        print("Email and password must be filled in.")
        return redirect("/")

@app.route('/success') 
def success():
    if("logged_in" not in session) or ("user_id" not in session) or (session['logged_in'] == False):
        flash("You do not have permission to view that site without being logged in.", 'failure')
        print("No permission to view site")
        return redirect('/')

    mysql = connectToMySQL('FavoriteBooks') #handles first name in header
    query = "SELECT first_name FROM users WHERE users.id = %(id)s;"
    data = {
        'id' : session['user_id']
    }
    firstname = mysql.query_db(query, data)
    print(firstname)
    mysql = connectToMySQL('FavoriteBooks')
    allbooks=mysql.query_db("SELECT id, creator, title FROM books")
    return render_template("success.html", name=firstname, books=allbooks)

@app.route('/books/new', methods=['POST'])
def add_book():
    print("*"*80)
    is_valid=True
    if("logged_in" not in session) or ("user_id" not in session) or (session['logged_in'] == False):
        flash("You do not have permission to view that site without being logged in.", 'failure')
        print("no permission to view site")
        return redirect('/')
    if len(request.form['title']) < 1: 
        flash("Please enter a full book title.", 'title')
        print("Invalid input - title field was not complete")
        is_valid = False
    if len(request.form['description']) < 4: 
        flash("Please enter a full description.", 'description')
        print("Invalid input - description field was not complete")
        is_valid = False

    if is_valid:
        mysql = connectToMySQL('FavoriteBooks')
        query = "INSERT INTO books (creator, title, description) VALUES (%(uid)s, %(title)s, %(des)s;"
        data = {
            'uid' : session['user_id'],
            'title' : request.form['title'],
            'des' : request.form['description'],
        }
        add=mysql.query_db(query, data)
        mysql = connectToMySQL('FavoriteBooks')
        query = "INSERT INTO favorites (book_id, user_id);"
        data = {
            '' : asdf
        }
        addToFavorites=mysql.query_db(query,data)
        print(session['user_id'])
        return redirect('/success')
    return redirect('/books/new')

@app.route('/books/<bookid>')
def show(bookid):
    if("logged_in" not in session) or ("user_id" not in session) or (session['logged_in'] == False):
        flash("You do not have permission to view that site without being logged in.", 'failure')
        print("no permission to view site")
        return redirect('/')
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT * FROM books WHERE id = %(book_id)s;"
    data = {
        'book_id' : bookid
    }
    bookinfo = mysql.query_db(query, data)
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT first_name FROM users WHERE id = %(id)s;"
    data = {
        'id' : session['user_id']
    }
    firstname = mysql.query_db(query, data)
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT users.first_name FROM books JOIN users ON books.creator = users.id WHERE books.id = %(id)s;"
    data = {
        'id' : bookid
    }
    creatorid = mysql.query_db(query,data)
    print(creatorid)
    print(session['user_id'])
    # if(session['user_id'] != creatorid[0]['creator']):
    #     flash("You do not have permission to view that book!")
    #     print("Not allowed to view book.")
    #     return redirect('/success')
    return render_template("show.html", bookid=bookinfo, name=firstname, created_by=creatorid)

@app.route('/books/edit/<bookid>')
def edit(bookid):
    if("logged_in" not in session) or ("user_id" not in session) or (session['logged_in'] == False):
        flash("You do not have permission to view that site without being logged in.", 'failure')
        print("No permission to view site")
        return redirect('/')        
    else:
        mysql = connectToMySQL('FavoriteBooks')
        query = "SELECT first_name FROM users WHERE id = %(id)s;"
        data = {
            'id' : session['user_id']
        }
        firstname = mysql.query_db(query, data)
        mysql = connectToMySQL('FavoriteBooks')
        query = "SELECT creator FROM books WHERE id = %(book_id)s;"
        data = {
        'book_id' : bookid
        }
        creatorid = mysql.query_db(query, data)
        print(creatorid)
        print(session['user_id'])
        if(session['user_id'] != creatorid[0]['creator']):
            flash("You do not have permission to edit that book!")
            print("Not allowed to edit book.")
            return redirect('/success')
        else:
            mysql = connectToMySQL('FavoriteBooks')
            query = "SELECT * FROM books WHERE id = %(book_id)s"
            data = {
                'book_id' : bookid
            }
            selectbook=mysql.query_db(query,data)
            return render_template("edit.html", name=firstname, bookid=selectbook)

@app.route("/books/edit/<bookid>", methods=["POST"]) #Actually pushes new user data to the server, avoid injection!
def editbook(bookid):
    is_valid = True
    if("logged_in" not in session) or ("user_id" not in session) or (session['logged_in'] == False):
        flash("You do not have permission to view that site without being logged in.", 'failure')
        print("No permission to view site")
        return redirect('/')        
    if len(request.form['title']) < 3:
        flash("Changes not saved. Please enter a full book name.", 'title')
        print("Invalid input - title field was not complete")
        is_valid = False
    if len(request.form['description']) < 3: 
        flash("Changes not saved. Please enter a full description.", 'description')
        print("Invalid input - description field was not complete")
        is_valid = False
    if is_valid:
        mysql = connectToMySQL('FavoriteBooks')
        query = 'UPDATE books SET creator = %(creator)s, title = %(title)s, description = %(desc)s WHERE id = %(book_id)s'
        data = {
            'creator' : session['user_id'],
            'title' : request.form['title'],
            'desc' : request.form['description'],
            'book_id' : bookid
        }
        editbook = mysql.query_db(query, data)
    return redirect('/success')

@app.route('/books/delete/<bookid>')
def delete_book(bookid):
    mysql = connectToMySQL('FavoriteBooks')
    query = "SELECT creator FROM books WHERE id = %(book_id)s;"
    data = {
    'book_id' : bookid
    }
    creatorid = mysql.query_db(query, data)
    if(session['user_id'] != creatorid[0]['creator']):
        flash("You do not have permission to delete that book!")
        print("Not allowed to delete book.")
        return redirect('/success')
    mysql = connectToMySQL('FavoriteBooks')
    query = "DELETE FROM books WHERE id = %(book_id)s;"
    data = {
        'book_id' : bookid
    }
    execute=mysql.query_db(query, data)
    print(execute)
    return redirect('/success')

@app.route('/logout') #handles logout button and deletes session
def logout():
    session.clear()
    return redirect('/')

if __name__=="__main__":
    app.run(debug=True)