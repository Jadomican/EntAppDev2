'''
# COMPOSITION
# return a new function which composes f and g
def compose(f, g):
        return lambda x: f(g(x))

# LAMBDA - anonymous functions
add = compose(lambda a: a + 1, lambda a: a + 1) 
x = add(12)
print (x)


z = lambda x,y: x*y
print(z(10, 5))

def make_incrementor (n): return lambda x: x + n
f = make_incrementor(2)
g = make_incrementor(6)
print (f(42), g(42))
print (make_incrementor(22)(33))
'''

'''
numbers = [1, 2, 18, 9, 22, 17, 24, 8, 12, 27]
# only print even numbers
print (list(filter(lambda x: x % 2 == 0, numbers)))
# square list and only print even numbers
print (list(map(lambda x : x**2,filter(lambda x: x % 2 == 0, numbers))))
# only print odd numbers
print (list(filter(lambda x: x % 2 != 0, numbers)))
# square list and only print odd numbers
print (list(map(lambda x : x**2,filter(lambda x: x % 2 != 0, numbers))))

# Reduce returns a single value from the function, not a list
from functools import reduce
print (reduce(lambda x, y: x + y, numbers))
print(sum(numbers))

# list COMPREHENSION (use map and reduce before this..
odd_digits_squared = [d**2 for d in numbers if d % 2 == 1]     # filter can be omitted
print (odd_digits_squared)
'''

'''
#RECURSION
print("~~~Recursion~~~")
def sum_range(start, end, acc):
    if (start > end):
        return acc
    return sum_range(start + 1, end, acc + start)
print(sum_range(1, 10, 0))

weekdays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
def print_days(start, end):
    if (start > end):
        return
    print(weekdays[start - 1])
    return print_days(start + 1, end)

start = input("Enter the first day number: ")
end = input("Enter the last day number: ")
print_days(int(start), int(end))
'''


# higher-order function - returns a function
def splitfullname():
    def firstname_surname(name):
        return name.split(' ')      # split into list of strings based on space
    return firstname_surname        # return a function (the inner function)

names = splitfullname()             # names is a function
print (names("Jason Domo"))


# HIGHER ORDER ADDER function - returns a function
def makeAdder(const_value):
    def adder(value):
        return const_value + value
    return adder
    
my_adder = makeAdder(15)
print(my_adder(30))


# return a new function which COMPOSES f and g
# f after g
def compose(f, g):
        return lambda x: f(g(x))
add5_after_multiply10 = compose(lambda a: a + 5, lambda a: a * 10) 
x = add5_after_multiply10(10)
print (x)

nums = [10, 20, 30]
map_variable = map(lambda x: x * x, nums)
print(list(map_variable))



