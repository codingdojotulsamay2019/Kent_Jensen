# Change the value 10 in x to 15. Once you're done, x should now be [ [5,2,3], [15,8,9] ].

x = [ [5,2,3], [10,8,9] ] 
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

def tenToFifteen():
    x[1][0] = 15
    print(x)
    return x
tenToFifteen()

# Change the last_name of the first student from 'Jordan' to 'Bryant'
def change_last():
    students[0].update({"last_name": "Bryant"})
    print(students)
    return(students)
change_last()
# In the sports_directory, change 'Messi' to 'Andres'
def sports_change():
    sports_directory['soccer'][0]='Andres'
    print(sports_directory)

sports_change()

# Change the value 20 in z to 30 ||   z = [ {'x': 10, 'y': 20} ]
def changeZ():
    z[0]['y'] = 30
    print(z)
changeZ()