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
    location: tigger
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