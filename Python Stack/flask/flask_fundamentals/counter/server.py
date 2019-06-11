from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)  
app.secret_key = 'keep it secret, keep it safe' # set a secret key for security purposes
@app.route('/')
def index():
    print("*"*80)
    print("counter increased from visit")
    print("*"*80)
    if "counter" in session:
        session['counter'] +=1
    else:
        session['counter'] = 0
    return render_template("index.html")

@app.route('/reset', methods=['POST'])
def reset():
    print("*"*80)
    print("RESETTING COUNTER")
    print("*"*80)
    session['counter'] = 0
    return redirect("/")

@app.route('/plustwo', methods=['POST'])
def plustwo():
    print("*"*80)
    print("ADDING TWO")
    print("*"*80)
    session['counter'] +=1
    return redirect("/")

@app.route('/show', methods=['POST'])
def show_user():
    return render_template('show.html')

@app.route('/destroy_session', methods=['POST'])
def destroy_session():
    session.clear()     # clears all keys
    return redirect("/")

if __name__=="__main__":   
    app.run(debug=True)    