from flask import Flask, request, redirect, render_template
app = Flask(__name__)

@app.route('/') #homepage
def index():
    return render_template("index.html")

@app.route('/result', methods=['POST']) #resultspage
def result():
    print("Got POST info")
    print(request.form)
    print(f"Name submitted: {request.form['name']}")
    print(f"Location submitted: {request.form['location']}")
    print(f"Language submitted: {request.form['language']}")
    print(f"Answer submitted: {request.form['learning']}")
    print(f"Comment submitted: {request.form['comment']}")
    return render_template("result.html", username=request.form["name"], loc=request.form["location"],lan=request.form["language"],learn=request.form["learning"],com=request.form['comment'])

if __name__=="__main__":
    app.run(debug=True)