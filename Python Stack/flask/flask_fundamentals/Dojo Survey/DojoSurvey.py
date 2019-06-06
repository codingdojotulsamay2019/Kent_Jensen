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
    print(f"Email submitted: {request.form['email']}")
    return render_template("result.html", username=request.form["name"], em=request.form["email"])

if __name__=="__main__":
    app.run(debug=True)