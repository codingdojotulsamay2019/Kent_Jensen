# USER CLASS
class User:
    def __init__(self, name, email, account_name, int_rate, balance):
        self.name = name
        self.email = email
        self.BankAccount = BankAccount(account_name,int_rate,balance)
    def make_deposit(self, amount):
        self.BankAccount.deposit(amount)
        return self
    def make_withdrawal(self,amount):
        self.BankAccount.withdraw(amount)
        return self
    def display_user_balance(self):
        print("User: ", self.name, ", Balance: $", self.BankAccount.balance)
        return self
    def transfer_money(self, other_user, amount):
        self.BankAccount.balance-=amount
        other_user.BankAccount.balance+=amount
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
larry = User("Larry Longfield", "larry@python.com","Savings",.08,10000)
#TEST AREA
print("GUIDO")
guido.make_deposit(100).make_deposit(500).make_deposit(200).make_withdrawal(300).display_user_balance()

print("*"*80)
print("*"*80)
print("MONTY")
monty.make_deposit(50).make_deposit(250).make_withdrawal(100).make_withdrawal(150).display_user_balance()

print("*"*80)
print("*"*80)
print("LARRY")
larry.make_deposit(1000).make_withdrawal(250).make_withdrawal(250).make_withdrawal(250).display_user_balance()

print("*"*80)
print("*"*80)
print("INITIATING TRANSFER")
print("*"*80)
print("*"*80)
print("STARTING BALANCES")
guido.display_user_balance()
larry.display_user_balance()
guido.transfer_money(larry,100)
print("ENDING BALANCES")
guido.display_user_balance()
larry.display_user_balance()
print("*"*80)
print("*"*80)
print("TRANSFER COMPLETE")
print("*"*80)
print("*"*80)

#Ending Account Balances
guido.display_user_balance()
monty.display_user_balance()
larry.display_user_balance()

