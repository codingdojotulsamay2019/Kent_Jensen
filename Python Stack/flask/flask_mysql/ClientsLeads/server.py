from flask import Flask, request, redirect, render_template
from MySQLConnection import connectToMySQL    # import the function that will return an instance of a connection
app = Flask(__name__)

@app.route('/') #root route to index page
def index():
    mysql = connectToMySQL('lead_gen_business')
    leads = mysql.query_db("SELECT clients.client_id, clients.first_name, clients.last_name, count(leads.leads_id) AS leadsbyclient FROM leads JOIN sites ON leads.site_id = sites.site_id JOIN clients ON sites.client_id = clients.client_id GROUP BY clients.client_id") #Need to join leads to sites, then sites to clients and get count of leads categorized by client_id
    return render_template("index.html",clients=leads)

if __name__=="__main__":
    app.run(debug=True)