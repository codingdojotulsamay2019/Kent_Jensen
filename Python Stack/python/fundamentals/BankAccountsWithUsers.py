# USER CLASS
class User:
    def __init__(self, name, email, balance, account):
        self.name = name
        self.email = email
        self.balance = balance
        self.account = account(int_rate = 0.02, balance = 0)
        self.int_rate = int_rate
    def make_deposit(self, amount):
        self.account.deposit(amount)
        return self
    def make_withdrawal(self,amount):
        self.account.withdraw(amount)
        return self
    def display_user_balance(self):
        print("User: ", self.name, ", Balance: $", self.balance)
        return self
    def transfer_money(self, other_user, amount):
        self.account.balance -= amount
        other_user.balance += amount
        print("Transferring $", amount)
    def account(self, account):
        self.account = account
        self.account.balance = self.balance


# BANK ACCOUNT CLASS
class account:
    def __init__(self, account, int_rate, balance):
        self.account = account
        self.int_rate = .025
        self.balance = 0+balance
    def deposit(self, amount):
        self.balance += amount
        print("Deposit of $", amount, "into", self.account, "account processed.")
        print("New Balance: $", self.balance)
        print("-"*50)
        return self
    def withdraw(self, amount):
        self.balance -= amount
        print("Withdrawal from",self.account, "in the amount of $",amount, "processed.")     
        print("New Balance: $", self.balance)
        print("-"*50)
        return self
    def display_account_info(self):
        print(self.account,"account ----- Balance: $", self.balance)
        print("-"*50)
    def yield_interest(self):
        print("*"*50)
        print("*"*50)
        print("Accumulating Interest on", self.account, "account")
        print("Before Interest: $", self.balance)
        self.balance = self.balance * (1+(self.int_rate))
        print("After Interest: $", self.balance)
        print("*"*50)
        print("*"*50)
        return self

#USER/ACCOUNT CREATION
guido = User("Guido van Rossum","guido@python.com",300,"Checking")
monty = User("Monty Python", "monty@python.com",500,"Checking")
larry = User("Larry Longfield", "larry@python.com",1000,"Savings")
#TEST AREA
guido.make_deposit(100).make_deposit(500).make_deposit(200).make_withdrawal(300).display_user_balance()

print("*"*80)
print("*"*80)

monty.make_deposit(50).make_deposit(250).make_withdrawal(100).make_withdrawal(150).display_user_balance()

print("*"*80)
print("*"*80)

larry.make_deposit(1000).make_withdrawal(250).make_withdrawal(250).make_withdrawal(250).display_user_balance()

print("*"*80)
print("*"*80)
print("INITIATING TRANSFER")
print("*"*80)
print("*"*80)
guido.display_user_balance()
larry.display_user_balance()
guido.transfer_money(larry,100)
guido.display_user_balance()
larry.display_user_balance()


