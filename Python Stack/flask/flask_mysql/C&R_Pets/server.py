from flask import Flask, render_template, redirect, request
from mysqlconn import connectToMySQL
app = Flask(__name__)      

@app.route('/')
def index():
    mysql = connectToMySQL("c&rpets")
    pets = mysql.query_db("SELECT * FROM pets;")
    print(pets)
    return render_template("index.html", all_pets = pets)

@app.route('/add', methods=["POST"])
def add():
    mysql = connectToMySQL("c&rpets")
    query = "INSERT INTO pets (name, type) VALUES(%(nm)s, %(tp)s);"
    data = {
        'nm' : request.form['name'],
        'tp' : request.form['type']
    }
    pets = mysql.query_db(query,data)
    return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)