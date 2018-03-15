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
