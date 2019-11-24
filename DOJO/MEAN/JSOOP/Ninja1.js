function Ninja(name, health=100, speed, strength) {
    this.speed = 1;
    this.strength = 1;
    this.name = name;
    this.health = health;
    var speed = speed;
    var strength = strength;
    var damage = strength*15;


    this.sayName = function() {
        console.log("My ninja name is "+this.name+"!");
    }
    this.showStats = function() {
        console.log("Name: "+this.name+", Health: "+this.health+", Speed: "+this.speed+", Strength: "+this.strength);
    }
    this.drinkSake = function() {
        this.health += 10;
    }
    this.punch = function(ninja) {
        ninja.health -= 5;
        console.log(this.name+" punched"+ninja.name+" in the face for 5 damage.")
    }
    this.kick = function(ninja) {
        ninja.health -= damage;
        console.log(this.name+" kicked "+ninja.name+" in the face for "+damage+" damage.")
    }
}




var blueNinja = new Ninja("Goemon");
var redNinja = new Ninja("Bill Gates");
redNinja.punch(blueNinja);
blueNinja.kick(redNinja);
// -> "Goemon was punched by Bill Gates and lost 5 Health!"






// var ninja1 = new Ninja("Hyabusa", 100, 3, 3);
// ninja1.sayName();
// // -> "My ninja name is Hyabusa!"
// ninja1.showStats();
// // -> "Name: Hyabusa, Health: 100, Speed: 3, Strength: 3"
// ninja1.drinkSake();
// // -> adds +10 Health to the ninja