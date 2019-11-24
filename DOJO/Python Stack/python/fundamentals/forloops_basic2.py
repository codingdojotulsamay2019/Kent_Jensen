# 1) Biggie Size - Given a list, write a function that changes 
# all positive numbers in the list to "big".
# Example: biggie_size([-1, 3, 5, -5]) returns that same list, 
# but whose values are now [-1, "big", "big", -5]

def biggie_size(list):
    for x in range(0,len(list),1):
        if list[x] > 0:
            list.remove(list[x])
            list.insert(x,"big")
    print(list) #not needed, just easier to view
    return list

biggie_size([-1,3,5,-5])

print("-"*80)
print("-"*80)

# 2) Count Positives - Given a list of numbers, create a function to 
# replace the last value with the number of positive values. 
# (Note that zero is not considered to be a positive number).
# Example: count_positives([-1,1,1,1]) changes the original list to [-1,1,1,3] and returns it
# Example: count_positives([1,6,-4,-2,-7,-2]) changes the list to [1,6,-4,-2,-7,2] and returns it

def count_positives(list):
    counter=0
    for x in range(0,len(list),1):
        if(list[x]>0):
            counter += 1
            print(counter)
    list.pop()
    list.append(counter)
    print(list) #not needed, just easier to view
    return(list)


count_positives([-1,1,1,1])
count_positives([1,6,-4,-2,-7,-2])

print("-"*80)
print("-"*80)
# 3) Sum Total - Create a function that takes a list and returns 
# the sum of all the values in the array.
# Example: sum_total([1,2,3,4]) should return 10
# Example: sum_total([6,3,-2]) should return 7

def sum_total(list):
    sum = 0
    for x in range(0,len(list),1):
        sum += list[x]
    print(sum) #not needed, just easier to view
    return(sum)

sum_total([1,2,3,4])
sum_total([6,3,-2])

print("-"*80)
print("-"*80)
# 4) Average - Create a function that takes a list and returns the average of all the values.
# Example: average([1,2,3,4]) should return 2.5

def average(list):
    sum = 0
    for x in range(0,len(list),1):
        sum += list[x]
    print(sum/len(list))
    return(sum/len(list))

average([1,2,3,4])

print("-"*80)
print("-"*80)
# 5) Length - Create a function that takes a list and returns the length of the list.
# Example: length([37,2,1,-9]) should return 4
# Example: length([]) should return 0

def length(list):
    print(len(list))
    return len(list)

length([37,2,1,-9])
length([])

print("-"*80)
print("-"*80)
# 6) Minimum - Create a function that takes a list of numbers and 
# returns the minimum value in the list. 
# If the list is empty, have the function return False.
# Example: minimum([37,2,1,-9]) should return -9
# Example: minimum([]) should return False

def minimum(list):
    if len(list) < 1:
        print("False")
        return False
    else:
        min = list[0]
        for x in range(0,len(list),1):
            if (list[x] < min):
                min = list[x]
    print(min)
    return min
    
minimum([37,2,1,-9])
minimum([])

print("-"*80)
print("-"*80)
# 7) Maximum - Create a function that takes a list and 
# returns the maximum value in the array. 
# If the list is empty, have the function return False.
# Example: maximum([37,2,1,-9]) should return 37
# Example: maximum([]) should return False

def maximum(list):
    if len(list) < 1:
        print("False")
        return False
    else:
        max = list[0]
        for x in range(0,len(list),1):
            if (list[x] > max):
                max = list[x]
    print(max)
    return max
    
maximum([37,2,1,-9])
maximum([])


print("-"*80)
print("-"*80)
# 8) Ultimate Analysis - Create a function that takes a list and
#  returns a dictionary that has the 
# sumTotal, average, minimum, maximum and length of the list.
# Example: ultimate_analysis([37,2,1,-9]) should return
# {'sumTotal': 31, 'average': 7.75, 'minimum': -9, 'maximum': 37, 'length': 4 }

def ultimate_analysis(list):
    ultDict = {
    "sumTotal":sum_total(list), 
    "average":average(list), 
    "minimum":minimum(list), 
    "maximum":maximum(list), 
    "length":len(list)}
    print(ultDict)
    return ultDict

ultimate_analysis([37,2,1,-9])

print("-"*80)
print("-"*80)

# 9) Reverse List - Create a function that takes a list and 
# return that list with values reversed. 
# Do this without creating a second list. 
# (This challenge is known to appear during basic technical interviews.)
# Example: reverse_list([37,2,1,-9]) should return [-9,1,2,37]

def reverse_list(list):
    list.reverse()
    print(list)
    return(list)

reverse_list([37,2,1,-9])

print("-"*80)
print("-"*80)