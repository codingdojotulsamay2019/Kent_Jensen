//Write a function that takes an array of numbers as a parameter. Find the maximum number, the minimum number, and the average of all the numbers in the array. Return these values in a nicely formatted string.
// Example: maxMinAvg([1, -2, 9, 4]) returns "The minimum is -2, the maximum is 9, and the average is 3."

function minMaxAvg(arr){
    var min = arr[0];
    var max = arr[0];
    var total = 0;
    for(i=0;i<arr.length; i++){
        total += arr[i];
        if(arr[i]<min){
            min=arr[i];
        }
        if(arr[i]>max){
            max=arr[i];
        }
    }
    return console.log("The minimum is " + min + ", the maximum value is " + max +", and the average is " + total/arr.length + ".")
}
minMaxAvg([1,-2,9,4]);