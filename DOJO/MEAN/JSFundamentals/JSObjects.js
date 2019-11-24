// Expected output:
// Name: Remy, Cohort: Jan
// Name: Genevieve, Cohort: March
// Name: Chuck, Cohort: Jan
// Name: Osmund, Cohort: June
// Name: Nikki, Cohort: June
// Name: Boris, Cohort: June

let students = [
    {name: 'Remy', cohort: 'Jan'},
    {name: 'Genevieve', cohort: 'March'},
    {name: 'Chuck', cohort: 'Jan'},
    {name: 'Osmund', cohort: 'June'},
    {name: 'Nikki', cohort: 'June'},
    {name: 'Boris', cohort: 'June'}
];

function printInfo(){
    for(x=0;x<students.length;x++){
        console.log("Name: "+students[x].name+", Cohort: "+students[x].cohort);
    }
}
printInfo();

// Expected output:
// EMPLOYEES
//  1 - JONES, MIGUEL - 11 (num = character count of fname+lname)
//  2 - BERTSON, ERNIE - 12
//  3 - LU, NORA - 6
//  4 - BARKYOUMB, SALLY - 14
//  MANAGERS
//  1 - CHAMBERS, LILLIAN - 15
//  2 - POE, GORDON - 9


let users = {
    employees: [
        {'first_name':  'Miguel', 'last_name' : 'Jones'},
        {'first_name' : 'Ernie', 'last_name' : 'Bertson'},
        {'first_name' : 'Nora', 'last_name' : 'Lu'},
        {'first_name' : 'Sally', 'last_name' : 'Barkyoumb'}
    ],
    managers: [
       {'first_name' : 'Lillian', 'last_name' : 'Chambers'},
       {'first_name' : 'Gordon', 'last_name' : 'Poe'}
    ]
 };
function printUsers(obj){
    for(x in users){
        console.log(x.toUpperCase())
        for(var i=0;i < obj[x].length; i++){
            console.log(i+1+" - "+obj[x][i].last_name.toUpperCase()+", "+obj[x][i].first_name.toUpperCase()+" - "+(obj[x][i].first_name.length+obj[x][i].last_name.length))
        }
    }
}
printUsers(users);