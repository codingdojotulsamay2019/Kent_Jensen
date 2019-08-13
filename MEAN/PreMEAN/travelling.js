var tigger = { character: "Tigger"};
var pooh = { character: "Winnie the Pooh"}
var piglet = { character: "Piglet"};
var bees = { character: "Bees"};
var owl = { character: "Owl"};
var chris = { character: "Christopher Robin"};
var rabbit = { character: "Rabbit"};
var gopher = { character: "Gopher"};
var kanga = { character: "Kanga"};
var eeyore = { character: "Eeyore"};
var heffa = { character: "Heffalumps"};
var player = {
    location: tigger
}
tigger.north = pooh;
pooh.west = piglet;
pooh.east = bees;
pooh.north = chris;
pooh.south = tigger;
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
heffa.east = eeyore;

document.onkeydown = function(e) {
    if(e.keyCode == 37) { //WEST
        if(player.location.west != null){
            player.location= player.location.west
            console.log("Going west.")
            console.log("You are at "+player.location.character+"'s house.")
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
        }
        else{
            console.log("No one lives in that direction.")
        }
    }
}