# 1. TASK: print "Hello World"
print("Hello World!")
# 2. print "Hello Noelle!" with the name in a variable
name = "Kent"
print("Hello",name + "!")	# with a comma
print("Hello " + name +"!")	# with a +
# 3. print "Hello 42!" with the number in a variable
num = "13" #!!! <--NINJA CHALLENGE - treat number as a string
print("Hello",num)	# with a comma
print("Hello" + num)	# with a +	-- this one should give us an error!
# 4. print "I love to eat sushi and pizza." with the foods in variables
fave_food1 = "cake"
fave_food2 = "fettuccine alfredo"
print("I love to eat {} and {}.".format(fave_food1, fave_food2)) # with .format() 
print(f"I love to eat {fave_food1} and {fave_food2}.") # with an f string
