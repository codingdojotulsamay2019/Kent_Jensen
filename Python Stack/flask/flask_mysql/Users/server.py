from flask import Flask, render_template, redirect, request
from MySQLConnection import connectToMySQL    # import the function that will return an instance of a connection
app = Flask(__name__)

# /users - GET - method should return a template that displays all the users in the table 
@app.route("/users")
def index():
    mysql = connectToMySQL('users')
    users = mysql.query_db('SELECT id,first_name,last_name,email,DATE_FORMAT(created_at, "%M %e, %Y") AS created_at FROM users;')
    return render_template('index.html', all_users=users)

# /users/new- GET - method should return a template containing the form for adding a new user 
@app.route("/users/new")
def new():
    mysql = connectToMySQL('users')
    users = mysql.query_db('SELECT * FROM users;')
    return render_template('create.html')

# /users/create - POST - method should add the user to the database, then redirect to /users/<id> 
@app.route("/users/create", methods=["POST"]) #Actually pushes new user data to the server, avoid injection!
def create():
    mysql = connectToMySQL('users')
    query = "INSERT INTO users (first_name, last_name, email) VALUES(%(fn)s, %(ln)s, %(em)s);"
    data = {
        'fn' : request.form['first_name'],
        'ln' : request.form['last_name'],
        'em' : request.form['email']
    }
    create = mysql.query_db (query,data)
    return redirect('/users/'+str(create))
    
# /users/<id> - GET - method should return a template that displays the specific user's information
@app.route("/users/<user_id>")
def show(user_id):
    mysql = connectToMySQL('users')
    query = "SELECT id,first_name,last_name,email,DATE_FORMAT(created_at, %(date)s) AS created_at,DATE_FORMAT(updated_at, %(dtime)s) AS updated_at FROM users WHERE users.id = %(id)s;"
    data = {
        "id" : user_id,
        "date" : "%%M %%e, %%Y",
        "dtime" : "%%M %%e, %%Y at %%l:%%i%%p"
    }
    show_user = mysql.query_db(query,data)
    return render_template('show.html', user_id = show_user)

# /users/<id>/edit - GET - method should return a template that displays a form for editing the user with the id specified in the url 
@app.route("/users/<user_id>/edit")
def edit(user_id):
    mysql = connectToMySQL('users')
    query = 'SELECT * FROM users WHERE users.id = %(id)s;'
    data = {
        'id' : user_id
    }
    edit_user = mysql.query_db(query,data)
    return render_template('update.html', user_id = edit_user)

# /users/<id>/update - POST - method should update the specific user in the database, then redirect to /users/<id> 
@app.route("/users/<user_id>", methods=["POST"]) #Actually pushes new user data to the server, avoid injection!
def update(user_id):
    mysql = connectToMySQL('users')
    query = "UPDATE users SET first_name = %(fn)s, last_name = %(ln)s, email = %(em)s WHERE id= %(id)s;"
    data = {
        'fn' : request.form['first_name'],
        'ln' : request.form['last_name'],
        'em' : request.form['email'],
        'id' : user_id
    }
    update = mysql.query_db (query,data)
    return redirect('/users/'+str(user_id))

# /users/<id>/destroy - GET - method should delete the user with the specified id from the database, then redirect to /users
@app.route("/users/<user_id>/destroy")
def destroy(user_id):
    mysql = connectToMySQL('users')
    query = "DELETE FROM users WHERE id = %(id)s;"
    data = {
        'id' : user_id
    }
    del_user= mysql.query_db (query,data)
    return redirect('/users')

if __name__ == "__main__":
    app.run(debug=True)
