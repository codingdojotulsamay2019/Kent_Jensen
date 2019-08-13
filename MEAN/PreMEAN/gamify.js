//Designed the game to accept keyboard inputs as well as console commands. 
console.log("Welcome to the Hundred Acre Wood! Use Up, Down, Left and Right arrow keys to move (or you can type move(''north'') [<--double quotes, not single.] Press M to start your mission or remind you of what your mission is. Press SPACE to pickup or drop off the honey!")
var tigger = { 
    character: "Tigger",
    greet: function(){
        console.log("Tigger says, 'The wonderful thing about Tiggers is Tiggers are wonderful things!'")
    }
};
var pooh = { 
    character: "Winnie the Pooh",
    greet: function(){
        console.log("Winnie the Pooh says, 'Oh bother.'")
    }
}
var piglet = { 
    character: "Piglet",
    greet: function(){
        console.log("Piglet says, 'The things that make me different are the things that make me ME.'")
    }
};
var bees = { 
    character: "Bees",
    greet: function(){
        console.log("*buzzzzzzzzzzzzzzzzzzzzz*")
    }
};
var owl = { 
    character: "Owl",
    greet: function(){
        console.log("Owl says, 'Have you seen Gopher? I think I heard him screaming a bit ago.'")
    }
};
var chris = { 
    character: "Christopher Robin",
    greet: function(){
        console.log("Christopher Robin says, 'Hello there, friend! Have you met some of my friends?'")
    }
};
var rabbit = { 
    character: "Rabbit",
    greet: function(){
        console.log("Rabbit says, 'No visitors! Shoo!'")
    }
};
var gopher = { 
    character: "Gopher",
    greet: function(){
        console.log("Gopher says, 'Well, I can't shhhh-tand around lollygaggin' all day. I've got a tight shhhh-cheduel. [falls down his hole] Waaaaahhh!!'")
    }
};
var kanga = { 
    character: "Kanga",
    greet: function(){
        console.log("Kanga says, 'Good morning, friend!'")
    }
};
var eeyore = { 
    character: "Eeyore",
    greet: function(){
        console.log("Eeyore says, 'Thanks for noticin’ me.'")
    }
};
var heffa = { 
    character: "Heffalumps",
    greet: function(){
        console.log("Heffalumps doesn't say anything, just watches you.")
    }
};
var player = {
    location: tigger,
    honey: false,
    quest: false
}
tigger.north = pooh;
pooh.north = chris;
pooh.south = tigger;
pooh.east = bees;
pooh.west = piglet;
piglet.east = pooh;
piglet.north = owl;
bees.west = pooh;
bees.north = rabbit;
owl.south = piglet;
owl.east = chris;
chris.west = owl;
chris.east = rabbit;
chris.north = kanga;
chris.south = pooh;
rabbit.south = bees;
rabbit.east = gopher;
rabbit.west = chris;
gopher.west = rabbit;
kanga.south = chris;
kanga.north = eeyore;
eeyore.south = kanga;
eeyore.east = heffa;
heffa.west = eeyore;

function move(str){
    if(str == "west") { //WEST
        if(player.location.west != null){
            player.location= player.location.west
            console.log("Going west.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }
    else if(str == "north") { //NORTH
        if(player.location.north != null){
            player.location= player.location.north
            console.log("Going north.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }
    else if(str == "north") { //EAST
        if(player.location.east != null){
            player.location= player.location.east
            console.log("Going east.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }
    else if(str == "south") { //SOUTH
        if(player.location.south != null){
            player.location= player.location.south
            console.log("Going south.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }
}

document.onkeydown = function(e) {
    if(e.keyCode == 32 && player.quest == true){
    
    if(player.location != bees) {
        drop();
    }
    else{
        pickUp();
    }
    }
    if(e.keyCode == 77){
        mission();
        player.quest = true;
    }
    if(e.keyCode == 37) { //WEST
        if(player.location.west != null){
            player.location= player.location.west
            console.log("Going west.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }

    else if(e.keyCode == 38) { //NORTH
        if(player.location.north != null){
            player.location= player.location.north
            console.log("Going north.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }

    else if(e.keyCode == 39) { //EAST
        if(player.location.east != null){
            player.location= player.location.east
            console.log("Going east.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }

    else if(e.keyCode == 40) { //SOUTH
        if(player.location.south != null){
            player.location= player.location.south
            console.log("Going south.")
            console.log("You are at "+player.location.character+"'s house.")
            player.location.greet()
        }
        else{
            console.log("No one lives in that direction.")
        }
    }
}
function pickUp() { //SPACE
    if(player.honey == false){
        if(player.location == bees && player.quest == true){
        player.honey = true;
        console.log("You've carefully gathered honey from the bees.")
        }
    }
    else {
        console.log("You already have some honey! Don't be greedy!")
    }
}
function mission() {
    if(player.quest == false){
        arr = [tigger,pooh,piglet,owl,chris,rabbit,gopher,kanga,eeyore,heffa]
        mission_location = arr[Math.floor((Math.random() * 10))];
        console.log("Your mission is to deliver the honey to "+mission_location.character+". Good luck!")
    }
    else{
        console.log("You already have a mission, deliver honey to "+mission_location.character+". Hurry it up already!")
    }
}
function drop(){
    if(player.honey == true){
        if(player.location == mission_location && player.honey == true){
            console.log("You've turned in the honey to "+mission_location.character+". Congratulations on your successful delivery!")
            player.honey = false;
            player.quest = false;
            return;
        }    
        else {
            player.quest = true;
            console.log("Uh oh! You've dropped the honey off at the wrong location. Go get some more from the bees!")
        }
    }
    else {
        console.log("You don't have any honey to drop off! Go gather some from the bees!")
    }
}