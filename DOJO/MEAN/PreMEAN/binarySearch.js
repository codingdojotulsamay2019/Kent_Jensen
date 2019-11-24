// Example: binarySearch([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94, 200], 93) returns -1 and should only take about 4 iterations.
// Example: binarySearch([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94], 15)returns 5.

function binarySearch(arr, num){
    var start = 0;
    var end = arr.length;
    if(arr.length<9){
        return "The array isn't long enough to waste time searching for a value. Have you tried using your eyes?";
    }
    while(Math.floor(end-start)>0){
        console.log("Entered loop!")
        console.log("Start is "+start)
        console.log("End is "+end)
        if(arr[start+Math.floor((end-start)/2)] == num){
            return start+Math.floor((end-start)/2);
        }
        if(arr[start+Math.floor((end-start)/2)] < num){
            start = start+Math.floor((end-start)/2);
        }
        else if(arr[start+Math.floor((end-start)/2)] > num){
            end = Math.floor((end-start)/2);
        }
    }
    return -1;
}
console.log(binarySearch([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94, 200], 93));
console.log(binarySearch([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94], 15));