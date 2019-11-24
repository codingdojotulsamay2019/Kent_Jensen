from flask import Flask, request, redirect, render_template
app = Flask(__name__)

@app.route('/')
def index():
    return render_template("index.html", horizontal=int(8), vertical=int(8) )
@app.route ('/<x>/<y>')
def size(x,y):
    return render_template("index.html", horizontal=int(x), vertical=int(y), color1="red", color2="black")
@app.route ('/<x>/<y>/<input1>/<input2>')
def size_color(x,y,input1,input2):
    return render_template("index.html", horizontal=int(x), vertical=int(y), color1=input1, color2=input2)


if __name__=="__main__":
    app.run(debug=True)

