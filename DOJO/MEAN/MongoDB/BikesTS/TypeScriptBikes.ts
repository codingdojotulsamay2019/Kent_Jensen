// price
// max_speed
// miles
// Create 3 instances of the Bike class.

// Use the constructor() function to specify the price and max_speed of each instance 
//(e.g. let bike1 = new Bike(200, "25mph"); also write the code so that the initial miles is set to be 0 whenever a new instance is created.
// 
// Add the following functions to this class:
// displayInfo() - have this method display the bike's price, maximum speed, and the total miles.
// ride() - have it display "Riding" on the screen and increase the total miles ridden by 10
// reverse() - have it display "Reversing" on the screen and decrease the total miles ridden by 5...
// Have the first instance ride three times, reverse once and have it displayInfo(). 
// Have the second instance ride twice, reverse twice and have it displayInfo(). 
// Have the third instance reverse three times and displayInfo().
// What would you do to prevent the instance from having negative miles?
// Which methods can return this in order to allow chaining methods?
// For assignment submission, upload a ".ts" file with the contents of the TypeScript Playground.

class Bike {
    price: number;
    max_speed: number;
    miles: number;

    constructor(price: number, max_speed: number, miles = 0){
        this.price = price;
        this.max_speed = max_speed;
        this.miles = 0;
    }
    displayInfo() {
        console.log("This is FUN!");
        console.log(this);
        return this;
    }
    ride(){
        console.log("Riding");
        this.miles += 10;
        return this;
    }
    reverse() {
        console.log("Reversing");
        if(this.miles <= 5){
            console.log("Can't go reverse any further, setting miles to zero.");
            this.miles = 0;
            return this;
        }
        else{
            this.miles -=5; 
            return this;
        }
    }
}
let firstBike = new Bike(200, 15);
let secondBike = new Bike(350, 30);
let thirdBike = new Bike(800, 35);

firstBike.ride().ride().ride().reverse().displayInfo();
secondBike.ride().ride().reverse().reverse().displayInfo();
thirdBike.reverse().reverse().reverse().displayInfo();

