$(document).ready(function() {
    $('.show p').hide();
    $('.slideDown p').slideUp();
    
    $('.show button').click(function() { //show
        $('.show p').show();
    })
    $('.addClass button').click(function() { //addClass red
        $('.addClass p').addClass("red");
    })
    $('.hide button').click(function() { //hide
        $('.hide p').hide();
    })        
    $('.toggle button').click(function() { //toggle
        $('.toggle p').toggle();
    })
    $('.slideDown button').click(function() { //slideDown
        $('.slideDown p').slideDown();
    })
    $('.slideUp button').click(function(){ //slideUp
        $('.slideUp p').slideUp();
    })
})