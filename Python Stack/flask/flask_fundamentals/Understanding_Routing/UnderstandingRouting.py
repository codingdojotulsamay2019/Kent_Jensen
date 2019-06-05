from flask import Flask
app = Flask(__name__)
@app.route('/')
def hello_world():
    return 'Hello World!'
if __name__=="__main__":
    @app.route('/dojo')
    def dojo():
        return 'Dojo!'
    @app.route("/say/<name>")
    def say(name):
        return 'Hi '+ name +'!'
    @app.route('/repeat/<x>/<str>')
    def repeat(x,str):
        return (str*int(x))
app.run(debug=True)