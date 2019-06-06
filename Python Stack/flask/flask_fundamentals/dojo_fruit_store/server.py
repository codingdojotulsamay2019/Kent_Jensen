from flask import Flask, render_template, request, redirect
app = Flask(__name__)  

@app.route('/')         
def index():
    return render_template("index.html")

@app.route('/checkout', methods=['POST'])         
def checkout():
    print(request.form)
    sberry = int(request.form["strawberry"])
    aberry = int(request.form["apple"])
    rberry = int(request.form["raspberry"])
    total = sberry + aberry + rberry
    Customer=request.form["first_name"] +" "+ request.form["last_name"]
    print("Charging " + Customer + " for " + str(total) + " fruit.")
    print(f"First Name: {request.form['first_name']}")
    print(f"Last Name: {request.form['last_name']}")
    print(f"Student ID: {request.form['student_id']}")
    return render_template("checkout.html", f_name=request.form["first_name"], l_name=request.form["last_name"],stuID=request.form["student_id"], sberry=request.form["strawberry"], aberry=request.form["apple"], rberry =request.form["raspberry"],tot=total)

@app.route('/fruits')         
def fruits():
    return render_template("fruits.html")

if __name__=="__main__":   
    app.run(debug=True)    