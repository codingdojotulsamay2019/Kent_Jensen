from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)  
app.secret_key = 'keep it secret, keep it safe' # set a secret key for security purposes
counter=0
@app.route('/')         
def index():
    print("counter increased from visit")
    counter +=1
    session['count'] = request.form['counter']
    return render_template("index.html")

app.route('/reset')
def reset():
    print("*"*80)
    print("RESETTING COUNTER")
    print("*"*80)
    session['count'] = 0
    return redirect["index.html"]
# @app.route('/users', methods=['POST'])
# def ():
#     print("Got Post Info")
#     # Here we add two properties to session to store the name and email
#     return redirect('/show')
@app.route('/show')
def show_user():
    return render_template('show.html')
@app.route('/destroy_session')
def destroy_session():
    counter = 0
    #delete the cookie?

if __name__=="__main__":   
    app.run(debug=True)    