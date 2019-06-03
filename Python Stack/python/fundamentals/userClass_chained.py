class User:
    def __init__(self, name, email_address):
        self.name = name
        self.email = email_address
        self.account_balance = 0
    def make_deposit(self, amount):
    	self.account_balance += amount
        return self	                    
    def make_withdrawal(self,amount):
        self.account_balance -= amount
        return self
    def display_user_balance(self): 
        print("User: ", self.name, ", Balance: $", self.account_balance)
        return self 
    def transfer_money(self, other_user, amount):   
        self.account_balance -= amount
        other_user.account_balance += amount     
        print("Transferring $", amount)                                       

guido = User("Guido van Rossum","guido@python.com")
monty = User("Monty Python", "monty@python.com")
larry = User("Larry Longfield", "larry@python.com")
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


