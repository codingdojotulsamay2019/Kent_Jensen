from flask import Flask, render_template, request, redirect
#Need Flask, render_template allows use of templated html files
#request for incoming request data
#redirect for redirection to target location.

app = Flask(__name__)    # Create a new instance of the Flask class called "app"




@app.route('/')
def domainroot(): #for domain level request. Default landing page.
    users = [
       {'first_name' : 'Michael', 'last_name' : 'Choi'},
       {'first_name' : 'John', 'last_name' : 'Supsupin'},
       {'first_name' : 'Mark', 'last_name' : 'Guillen'},
       {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
    length1 = len(users)
    return render_template('users.html', people = users, length = length1)



@app.route('/', defaults={'path': ''})  #catches all other unspecified routes
@app.route('/<path:path>')              #Useful as a 404 response
def deliver404(path):
    return 'Your princess is in another castle.'



if __name__=="__main__":   # Ensure this file is being run directly and not from a different module
    app.run(debug=True)
