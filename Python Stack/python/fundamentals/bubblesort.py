arr=[0,4,7,2,8,5,6,3,1]
def bubblesort(arr):
    for j in range(len(arr)-1):
        for i in range(len(arr)-1-j):
            #print("\n","*"*80, "\nindex ", i, "value", arr[i])
            print("\n","*"*80, "\ncomparing", arr[i], arr[i+1])
            if arr[i] > arr[i+1]:
                arr[i], arr[i+1] = arr[i+1], arr[i]
                print('swapped', arr[i], arr[i+1])
                print('array is now', arr)
            else:
                print('no need to swap',arr[i], arr[i+1])
bubblesort(arr)
