$(document).ready(function() {
    
    $(this).hover(function {
        // var front = $(this).attr('data-alt-src');
        // var back = $(this).attr('src');
        (function(){$(this).attr('src')}),
        (function(){$(this).attr('data-alt-src')})
    })
})

//APPLY HTML
// $('p, h3, li').hover(
//     function() {$(this).css('color','white');},
//     function() {$(this).css('color','black');

    