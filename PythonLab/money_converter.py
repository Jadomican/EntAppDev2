#Jason Domican EAD2 exercise

# Dictionary of euro-to-x exchange rates
euro_rates = {'USD': 1.2, 'CAD': 1.0, 'GBP': 0.85}

def convert_from_euro(value, to_currency):
    return value * euro_rates[to_currency]


def convert_to_euro(value, from_currency):
    return value * (1 / euro_rates[from_currency])

print(convert_from_euro(100, 'USD'))
print(convert_to_euro(100, 'USD'))


from functools import reduce

euro_account = []

def balance(trans):
    return sum(trans)


def debit(amount, account):
    if amount > 0:
        account.append(amount)
    else:
        raise ValueError('Invalid Account')

def credit(amount, account):
    if amount > 0:
        if (amount <= balance(account)):
            account.append(-amount)
        else:
            raise ValueError('insufficient funds')
    else:
        raise ValueError('invalid amount')



debit(100, euro_account)
debit(200, euro_account)
credit(50, euro_account)
print("Euro Account Transactions: " + str(euro_account))
print(balance(euro_account))

#Format string output
def format(a, b):
    output = ''
    print("a:")
    print(a)
    print("b:")
    print(b)
    if b > 0:
        output += 'credit: '
    else:
        output += 'debit: '
    return str(a) + output + str(b) + ' '
output = reduce(format, euro_account, '')   #reduce() places the optional 3rd parameter before the values of the second argument, if present.
print(output)

#convert to dollars
dollar_account = map(lambda euro: convert_from_euro(euro, 'USD'), euro_account)
print(list(dollar_account))
print(balance(dollar_account))

output_dollar = reduce(format, dollar_account, '')
print(output_dollar)

