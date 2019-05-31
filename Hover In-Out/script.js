$(document).ready(function() {
    
    $('img').hover(function() {
        // var front = $(this).attr('data-alt-src');
        // var back = $(this).attr('src');
        $(this).attr('src',"img/back.jpg")
    }, function() {
        $(this).attr('src',"img/front.jpg")
    })
})


        // (function() {$(this).html('<img src="img/front.jpg", data-alt-src="img/back.jpg">')
