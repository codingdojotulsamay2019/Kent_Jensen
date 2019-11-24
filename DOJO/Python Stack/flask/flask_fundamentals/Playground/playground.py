from flask import Flask, request, redirect, render_template
app = Flask(__name__)

@app.route('/')
def index():
    return render_template("index.html", num_times=int(3), fillcolor="blue")
@app.route ('/play/<times>')
def times(times):
    return render_template("index.html", num_times=int(times), fillcolor="blue")
@app.route('/play/<times>/<color>')
def play(times,color):
    return render_template("index.html", num_times=int(times), fillcolor=color)
if __name__=="__main__":
    app.run(debug=True)