// Given a string, write a function that will determine whether the braces  - including parentheses (), square brackets [], and curly brackets {} - within the string are valid. That means that any braces within other braces must close before the outer set closes.
// HINT: Keep in mind that you may use arrays and objects to keep your information organized!
// Example: bracesValid("{{()}}[]") returns true because the inner braces close before the outer braces. Each opening brace has a matching closing brace.
// Example:  bracesValid("{(})") returns false because the curly braces close before the parentheses, which starts within the curly braces, had a chance to close.

//worked on this with Mason

function bracesValid(str){
    if (str.length <= 1)
    {
        return false
    }
    
    stack = []
    
    openingBrackets = ['[', '{', '(']
    closingBrackets = [']', '}', ')']
    
    for (i = 0; i < str.length; i++) 
    {
        char = str[i]
    
        if (closingBrackets.indexOf(char) > -1) 
        {
            matchingOpeningBracket = openingBrackets[closingBrackets.indexOf(char)]
            if (stack.length == 0 || (stack[stack.length-1] != matchingOpeningBracket)) 
            {
                return false
            }
            stack.pop();
        } 
        else 
        {
            stack.push(char)
        }
    }
    return (stack.length == 0)
}