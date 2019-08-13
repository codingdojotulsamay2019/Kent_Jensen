// Given a number of US cents, return the optimal configuration (meaning the largest denominations possible) of coins in an object. 
// Use dollars, quarters, dimes, nickels, and pennies.
// Example: coinChange(312) returns 
// {dollars: 3, dimes: 1, pennies: 2}

function coinChange(num){
    var myDict = {}
    var dollars = 0;
    var quarters = 0;
    var dimes = 0;
    var nickles = 0;
    var pennies = 0;
    var temp = num;
    while(temp >= 100){
        temp -=100;
        dollars +=1;
    }
    myDict["dollars"] = dollars;
    while(temp >=25){
        temp -=25;
        quarters +=1;
    }
    myDict["quarters"] = quarters;
    while(temp >= 10){
        temp -=10;
        dimes +=1;
    }
    myDict["dimes"] = dimes;
    while(temp >=5){
        temp-=5;
        nickles +=1;
    }
    myDict["nickles"] = nickles;
    pennies = temp;
    myDict["pennies"] = pennies;
    console.log(myDict);
    return myDict;
    }
coinChange(312)