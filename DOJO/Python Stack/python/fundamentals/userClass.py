class User:
    def __init__(self, name, email_address):
        self.name = name
        self.email = email_address
        self.account_balance = 0
    def make_deposit(self, amount):	# takes an argument that is the amount of the deposit
    	self.account_balance += amount	# the specific user's account increases by the amount of the value received
    def make_withdrawal(self,amount): #takes an argument that is the amount of the withdrawal
        self.account_balance -= amount
    def display_user_balance(self): #- have this method print the user's name and account balance to the terminal
        print("User: ", self.name, ", Balance: $", self.account_balance) #eg. "User: Guido van Rossum, Balance: $150
    def transfer_money(self, other_user, amount):   # have this method decrease the user's balance                    # by the amount and add that amount to other other_user's balance
        self.account_balance -= amount
        other_user.account_balance += amount     
        print("Transferring $", amount)                                       


guido = User("Guido van Rossum","guido@python.com")
monty = User("Monty Python", "monty@python.com")
larry = User("Larry Longfield", "larry@python.com")
guido.make_deposit(100)
guido.make_deposit(500)
guido.make_deposit(200)
guido.make_withdrawal(300)
guido.display_user_balance()
print("*"*80)
print("*"*80)

monty.make_deposit(50)
monty.make_deposit(250)
monty.make_withdrawal(100)
monty.make_withdrawal(150)
monty.display_user_balance()
print("*"*80)
print("*"*80)

larry.make_deposit(1000)
larry.make_withdrawal(250)
larry.make_withdrawal(250)
larry.make_withdrawal(250)
larry.display_user_balance()
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


