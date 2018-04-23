from functools import reduce

'''
#Task 1
#Iterative
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

'''
name = input("Please enter your name: ")
print("Hello, " + name)

age = int(input("Please enter your age: "))

if age > 18:
    print("You are an adult")
else:
    print("You are a child")
'''

'''
#Task 3
def hyphenated(sentence):
h    words = sentence.split()
    words.sort()
    joined = '-'.join(words)
    return joined

sentence = input("Enter a string of words: ")
print(hyphenated(sentence))
'''

'''
#Task 4
# perfect number
def perfect_number(n):  
    sum = 0  
    for x in range(1, n):               # to n - 1
        if n % x == 0:                  # proper divisor
            sum += x  
    return sum == n  
print(perfect_number(28))
'''

'''
#https://stackoverflow.com/questions/30671876/trial-division-faster-than-sieve-for-primality-test
#Task 5
import math
def is_prime(number):
    u = math.floor(math.sqrt(number))
    i = 2
    while (i <= u):
        if (number % i == 0):
            return False
        i+= 1
    return True

print(is_prime(7))  #True
print(is_prime(71)) #True
print(is_prime(10)) #False
'''

'''
#Task 6
def is_palindrome_simple(word):
    return word == word[::-1]
print(is_palindrome_simple('JasaJ'))

def is_palindrome_recur(word):
    if len(word) < 2:
        return True
    if word[0] != word[-1]:
        return False
    return is_palindrome_recur(word[1:-1])
print(is_palindrome_recur('racecar'))
print(is_palindrome_recur('Jason'))
'''

'''
#Task 7 (Fibonacci)
def get_fibonacci(number):
    if number == 0:
        return 0
    elif number == 1:
        return 1
    else:
        return get_fibonacci(number - 1) + get_fibonacci(number - 2)
list_fibonacci_numbers = [get_fibonacci(i) for i in range(0, 10)]
print (list_fibonacci_numbers)
'''     


#Task 8
# implement a function which multiplies the numbers in list by each other, ignoring items in the
# list which are zero
# e.g. [3, 0, 5] gives 15
# [2, 4, 5] gives 40
# use reduce
'''
def product(a, b):
    if (a == 0) and (b == 0):
        return 0
    elif (a == 0) and (b != 0):
        return b
    elif (a != 0) and (b == 0):
        return a
    else:
        return a * b

ans = reduce(product, [3, 0, 5] )
print (ans)

# or use filter to filter out 0s
ans = reduce(product, filter(lambda i: i != 0, [3, 5, 0]))
print (ans)
'''

#Task 9 - factorial
# define a function which calculates n factorial
# factorial - recursive
'''
def factorial(n):
    if n == 0:
        return 1
    else:
        return n * factorial(n-1)

print(factorial(10))

# initialise a list of digits and map factorial to the list
digits = list(range(1, 10))
factorial_digits = map(factorial, digits)
print (list(factorial_digits))
'''


#Task 10
'''
exclude_words = ['the', 'is', 'and']

def count_words(a, b):
    if (b not in exclude_words):
        return a + 1
    else:
        return a

text = ['welcome', 'to', 'the' , 'jungle']

# 0 is an initialiser for a. Otherwise will be initialised as string
wordcount = reduce(count_words, text, 0)
print(wordcount)
'''

#Task 11 (closure)

#Write a function using a closure which allows the day of week in English or
#Irish to be determined for a specified day number (1 .. 7). The function takes
#the language as an input and returns a function which takes the day number as input.
'''
def language_days(lang):
    if lang == "english":
        days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
    else:
        days = ['Luain', 'Mhairt', 'Cheadaoin', 'Deardoin', 'Aoine', 'Satharn', 'Domhnach']
    def day(n):
        if n >= 1 and n <= len(days):
            return days[n-1]
        else:
            raise Exception
    return day

day = language_days("english")
print(day(3))
day = language_days("irish")
print(day(3))
'''


squared = lambda x : x * x
print(squared(10))


sample_list = [4, 6, 2, 7, 7, "hello", "hello", "hello", 'list']
print(sample_list)

sample_tuple = {4, 6, 2, 7, "hello", "hello", "hello", 'tuple'}
print(sample_tuple)

