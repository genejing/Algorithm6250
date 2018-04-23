using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {6,5,3,1,2,7,8,4};
            PancakeSort(arr);
            Console.WriteLine();
        }

        static void Swap(int[] arr, int i, int j){
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

        }
        static void BubbleSort(int[] arr){
            for(int i = 0 ; i < arr.Length; i ++){

                for(int j = 0; j < arr.Length -i; j++){
                    if(arr[i] > arr[j]){
                        Swap(arr, i, j);
                    }

                }
            }
            
        }

        static void SelectionSort(int[] arr){
            int minIndex = 0;
            for(int i =  0; i < arr.Length ; i ++){
                minIndex  = i;
                for(int j = i+1; j < arr.Length ; j ++){
                    if(arr[j] < arr[minIndex])
                        minIndex = j;
                }
                if(i != minIndex){
                    Swap(arr, i, minIndex);
                }

            }
        }

        static void MergeSort(int[] arr){

            MergeSortAux(arr, 0, arr.Length -1);
        }

        static void MergeSortAux(int[] arr, int low, int high){
            if(low >= high){
                return;
            }
            int mid = (low + high)/2;
            MergeSortAux(arr, low, mid);
            MergeSortAux(arr, mid+1, high);
            Merge(arr, low, high);

        }

        static void Merge(int[] arr, int low, int high){
            int mid = (low + high)/2;
            int[] temp = new int[high -low +1];

            int i = low;
            int j = mid +1;
            int curr = 0;

            while(i <= mid && j <=high){
                if(arr[i] < arr[j]){
                    temp[curr] = arr[i];
                    i++;
                }else{
                    temp[curr] = arr[j];
                    j++;
                }
                curr ++;
            }
            // Copy over remaining
            while(i<=mid){
                temp[curr] = arr[i];
                i++;
                curr++;
                //temp[curr++] = arr[i++];
            }

            while(j<=high){
                temp[curr] = arr[j];
                j++;
                curr++;
                //temp[curr++] = arr[j++];
            }

            // Copy temp arr into original
            i = low;
            for(int k = 0; k < temp.Length; k ++){
                arr[i] = temp[k];
                i++;
            }
        }

        static void QuickSort(int[] arr){

            QuickSort(arr, 0, arr.Length -1);
        }

        static void QuickSort(int[] arr, int low, int high){

            if(low < high){

                int wall = Partition(arr, low, high);
                QuickSort(arr, low, wall-1);
                QuickSort(arr, wall+1, high);
            }
        }

        static int Partition(int[] arr, int low, int high){

            int pivot = arr[high];
            int wall = low - 1;

            for(int i = low; i < high ; i ++){

                if(arr[i] <= pivot){
                    wall ++;
                    Swap(arr, i, wall);
                }
            }

            Swap(arr, high, wall+1);
            return wall +1;
        }

        static int RANGE = 10;
        static void CountSort(int[] arr){
            int[] count = new int[RANGE];

            for(int i = 0 ; i < arr.Length ; i ++)
                count[arr[i]] ++;
            int index = 0;
            for(int i = 0 ; i < RANGE ; i ++){

                while(count[i] >0){

                    arr[index]= i;
                    index ++;
                    count[i]--;
                }
            }

        }

        static void PancakeSort(int[] arr){
            for(int i = 0 ; i < arr.Length ; i ++){
                int min = FindMin(arr, i, arr.Length);
                Flip(arr, i, min);
            }

        }

        static int FindMin(int[] arr, int low, int high){
            int min = low;
            for(int i = 0; i < high; i ++){
                if(arr[min] > arr[i])
                    min = i;
            }
            return min;

        }

        static void Flip(int[] arr, int low, int high){

            while(low < high){
                Swap(arr, low, high);
                low ++;
                high--;

            }
        }

        


    }
}
