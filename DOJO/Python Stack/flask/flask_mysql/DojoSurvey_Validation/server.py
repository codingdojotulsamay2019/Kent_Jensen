from flask import Flask, request, redirect, render_template, session, flash
from MySQLConnection import connectToMySQL    # import the function that will return an instance of a connection
app = Flask(__name__)
app.secret_key= "keep it secret, keep it safe"
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/result', methods=['POST']) #resultspage
def result():
    is_valid = True		# assume True
    mysql = connectToMySQL('DojoSurvey_Validation')
    if len(request.form['first_name']) < 1:
        is_valid = False
        flash("Please enter a first name")
        print("First Name Failed")
    if len(request.form['last_name']) < 1:
        is_valid = False
        flash("Please enter a last name")
        print("Last Name Failed")
    if len(request.form['comment']) > 120:
        is_valid = False
        flash("Please limit your comment to 120 characters")
        print("Comment Failed")

    if not is_valid:    # if any of the fields switched our is_valid toggle to False
        return redirect('/')    # redirect back to the method that displays the index page
    else:               # if is_valid is still True, all validation checks were passed
        query = "INSERT INTO users (first_name, last_name, fav_lang, learning, location, comment) VALUES(%(fn)s, %(ln)s, %(fl)s, %(lrn)s, %(loc)s, %(cm)s);"
        data = {
        'fn' : request.form['first_name'],
        'ln' : request.form['last_name'],
        'fl' : request.form['fav_lang'],
        'lrn' : request.form['learning'],
        'loc' : request.form['location'],
        'cm' : request.form['comment']
        }
        result = mysql.query_db(query,data)# add user to database
        print(result)
        # display success message
        # redirect to a method that displays a success page
    return redirect("/post/"+str(result))

@app.route('/post/<id>')
def post(id):
    mysql = connectToMySQL('DojoSurvey_Validation')
    query = "SELECT * FROM users WHERE id = %(id)s"
    data = {
        'id' : id
    }
    post = mysql.query_db(query,data)
    return render_template('result.html', render = post)
if __name__=="__main__":
    app.run(debug=True)
