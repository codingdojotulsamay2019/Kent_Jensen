arr=[0,4,7,2,8,5,6,3,1]
function bubblesort(arr){
    for(j=0;j<arr.length-1;j++){
        console.log("\n\n", "-"*100, "Iteration", j)
        for(i = 0;i<arr.length-1-j;i++){
            console.log("\n","*"*80, "\ncomparing", arr[i], arr[i+1])
            if(arr[i] > arr[i+1]){
                temp = arr[i]
                arr[i] = arr[i+1]
                arr[i+1] = temp
                console.log('swapped', arr[i], arr[i+1])
                console.log('array is now', arr)
            }
            else{
                console.log('no need to swap',arr[i], arr[i+1])
            }
        }
    }
}
bubblesort(arr)
