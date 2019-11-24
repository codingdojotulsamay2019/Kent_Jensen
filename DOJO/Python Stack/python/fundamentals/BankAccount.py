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
    
Checking = BankAccount("Checking", 0.025, 500)
Savings = BankAccount("Savings", 0.08, 19000)
print("*"*80)
print("*"*80)    
Checking.deposit(250).deposit(500).deposit(250).withdraw(500).yield_interest().display_account_info()
print("*"*80)
print("*"*80)
print("*"*80)
Savings.deposit(2500).deposit(2500).withdraw(1000).withdraw(1000).withdraw(1000).withdraw(1000).yield_interest().display_account_info
print("*"*80)
print("*"*80)        