# Problem 1)
#  Change the value 10 in x to 15. Once you're done, x should now be [ [5,2,3], [15,8,9] ].

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

print('-'*80)
print('-'*80)

# Change the last_name of the first student from 'Jordan' to 'Bryant'

def change_last():
    students[0].update({"last_name": "Bryant"})
    print(students)
    return(students)
change_last()
print('-'*80)
print('-'*80)

# In the sports_directory, change 'Messi' to 'Andres'

def sports_change():
    sports_directory['soccer'][0]='Andres'
    print(sports_directory)

sports_change()
print('-'*80)
print('-'*80)

# Change the value 20 in z to 30 ||   z = [ {'x': 10, 'y': 20} ]

def changeZ():
    z[0]['y'] = 30
    print(z)
changeZ()

print('-'*80)
print('-'*80)
print('-'*80)

# Problem 2)

students = [
    {'first_name':  'Michael', 'last_name' : 'Jordan'},
    {'first_name' : 'John', 'last_name' : 'Rosales'},
    {'first_name' : 'Mark', 'last_name' : 'Guillen'},
    {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
def iterateDictionary(students):
    for student in students:
        result = ""
        for name in student:
            result += name + ' - ' + student[name] + ', '
        result = result [0:-2]
        print(result)
    
iterateDictionary(students)

# should output: (it's okay if each key-value pair ends up on 2 separate lines;
# bonus to get them to appear exactly as below!)
# first_name - Michael, last_name - Jordan
# first_name - John, last_name - Rosales
# first_name - Mark, last_name - Guillen
# first_name - KB, last_name - Tonel

print('-'*80)
print('-'*80)
print('-'*80)

# Problem 3)
def iterateDictionary2(key, some_list):
    # print(key)
    # print(some_list)
    for value in some_list:
        print(value[key])

iterateDictionary2('first_name', students)
iterateDictionary2('last_name', students)
# output
# Michael
# John
# Mark
# KB

# output
# Jordan
# Rosales
# Guillen
# Tonel

print('-'*80)
print('-'*80)
print('-'*80)

# Problem 4)
dojo = {
   'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}
def printInfo(some_dict):
    for key in some_dict:
        print(str(len(some_dict[key])) + ' ' + key.upper())
        for location in some_dict[key]:
            print(location)
printInfo(dojo)

def tupleunpacking(some_dict):
    for key, value in some_dict.items():
        print(key)
        print(value)
    for key in some_dict.items():
        print(key)
        print(type(key))

#tupleunpacking(dojo)

# # output:
# 7 LOCATIONS
# San Jose
# Seattle
# Dallas
# Chicago
# Tulsa
# DC
# Burbank
    
# 8 INSTRUCTORS
# Michael
# Amy
# Eduardo
# Josh
# Graham
# Patrick
# Minh
# Devon
