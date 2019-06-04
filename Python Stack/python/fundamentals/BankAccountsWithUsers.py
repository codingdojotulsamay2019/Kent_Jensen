# USER CLASS
class User:
    def __init__(self, name, email, account_name, int_rate, balance):
        self.name = name
        self.email = email
        self.BankAccount = BankAccount(account_name,int_rate,balance)
        self.BankAccount.name = account_name
        self.BankAccount.int_rate = int_rate
        self.BankAccount.balance = balance
    def make_deposit(self, amount):
        BankAccount.deposit(self,amount)
        return self
    def make_withdrawal(self,amount):
        BankAccount.withdraw(self,amount)
        return self
    def display_user_balance(self):
        print("User: ", self.name, ", Balance: $", BankAccount.balance)
        return self
    def transfer_money(self, other_user, amount):
        BankAccount.balance(- amount)
        other_user.BankAccount.balance(+ amount)
        print("Transferring $", amount)


# BANK ACCOUNT CLASS
class BankAccount:
    def __init__(self, name, int_rate, balance):
        self.name = name
        self.int_rate = .025
        self.balance = 0+balance 
    def deposit(self, amount):
        self.balance += amount
        print("Deposit of $", amount, "into", self.name, "Account processed.")
        print("New Balance: $", self.balance)
        print("-"*50)
        return self
    def withdraw(self, amount):
        self.balance -= amount
        print("Withdrawal from",self.name, "in the amount of $",amount, "processed.")     
        print("New Balance: $", self.balance)
        print("-"*50)
        return self
    def display_account_info(self):
        print(self.name,"Account ----- Balance: $", self.balance)
        print("-"*50)
    def yield_interest(self):
        print("*"*50)
        print("*"*50)
        print("Accumulating Interest on", self.name, "Account")
        print("Before Interest: $", self.balance)
        self.balance = self.balance * (1+(self.int_rate))
        print("After Interest: $", self.balance)
        print("*"*50)
        print("*"*50)
        return self

#USER/ACCOUNT CREATION
guido = User("Guido van Rossum","guido@python.com","Checking",.02,1500)
monty = User("Monty Python", "monty@python.com","Checking",.02,800)
larry = User("Larry Longfield", "larry@python.com","Savings",.02,10000)
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


