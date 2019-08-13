// EXPECTED OUTPUT:
// Kermit the Frog knows Python, JavaScript, C#, HTML, CSS, and SQL. 
// Winnie the Pooh knows Python, Swift, and Java. 
// Arthur Dent knows JavaScript, HTML, and Go.

users = [
    {
    fname: "Kermit",
    lname: "the Frog",
    languages: ["Python", "JavaScript", "C#", "HTML", "CSS", "SQL"],
    interests: {
        music: ["guitar", "flute"],
        dance: ["tap", "salsa"],
        television: ["Black Mirror", "Stranger Things"]
        }
    },
    {
    fname: "Winnie",
    lname: "the Pooh",
    languages: ["Python", "Swift", "Java"],
    interests: {
        food: ["honey", "honeycomb"],
        flowers: ["honeysuckle"],
        mysteries: ["Heffalumps"]
        }
    },
    {
    fname: "Arthur",
    lname: "Dent",
    languages: ["JavaScript", "HTML", "Go"],
    interests: {
        space: ["stars", "planets", "improbability"],
        home: ["tea", "yellow bulldozers"]
        }
    }
]

function userLanguages(arr){
    var string="";
    for(var i=0; i<arr.length; i++)
    {
        string+= arr[i].fname+" "+arr[i].lname+" knows ";
        for(var j=0; j<arr[i].languages.length; j++){
            if(j<arr[i].languages.length-1){
                string+= arr[i].languages[j]+", ";
                if(j==arr[i].languages.length-2){
                    string+="and "
                }
            }
        else{
            string+= arr[i].languages[j]+". \n";
        }
        }
    }
    console.log(string);
    return string;
}
userLanguages(users);