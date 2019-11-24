from flask import Flask, render_template
app = Flask(__name__)
@app.route('/')
def index():
    return render_template("index.html", phrase="hello", times=5)	# notice the 2 new named arguments!
if __name__=="__main__":

# import statements, maybe some other routes
    @app.route('/success')
    def success():
        return "success"
    @app.route('/hello/<name>') # for a route '/hello/____' anything after '/hello/' gets passed as a variable 'name'
    def hello(name):
        print(name)
        return "Hello, " + name
app.run(debug=True)    # Run the app in debug mode.