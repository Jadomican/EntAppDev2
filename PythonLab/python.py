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
    words = sentence.split()
    words.sort()
    joined = '-'.join(words)
    return joined

sentence = input("Enter a string of words: ")
print(hyphenated(sentence))
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
