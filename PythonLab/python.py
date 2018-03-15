'''
#Iterative (task 1)
def iterativesum():
    total = 0
    for i in range(1, 11):
        total += i
    return total

#Recursive function
def sumrange(start, end, total):
    if start > end:
        return total
    return sumrange(start + 1, end, total + start)

sumtotal = sum(range(1, 11))

print(iterativesum())
print(sumrange(1, 10, 0))
print(sumtotal)
'''

'''
#Task 2
list = [4, 6, 9, 3, 6, 2, 6, 1, 6, 8, 2]
print(list)
unique_list = set(list)     #Convert list to set - collection of distinct objects
print(unique_list)
'''

name = input("Please enter your name: ")
print("Hello, " + name)

age = int(input("Please enter your age: "))

if age > 18:
    print("You are an adult")
else:
    print("You are a child")

list 
