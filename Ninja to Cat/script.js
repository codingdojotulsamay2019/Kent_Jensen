$(document).ready(function() {
  $('img').click(function() {
    var poof = $(this).attr('data-alt-src')
    var unpoof = $(this).attr('src')
    $(this).attr('src',poof)
    $(this).attr('data-alt-src',unpoof)    
  })
})
