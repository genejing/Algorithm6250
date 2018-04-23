using System;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,0,5,-12,0,-1, 3,4,0,-2,6};
            DutchFlag(arr, 0);
            Console.WriteLine();
        }

        static bool BinarySearch(int[] arr, int x){
            int low = 0;
            int high = arr.Length -1;
            while(low<= high){
                int mid = (low + high)/2;
                if(arr[mid] == x){
                    return true;
                }
                else if(arr[mid] < x){
                    low = mid+1;
                }
                else{
                    high = mid-1;
                }
            }
            return false;
        }

        static bool BinSearchRecursive(int[] arr, int x){

            return BinSearchRecursive(arr, x, 0, arr.Length -1);
        }
        static bool BinSearchRecursive(int[] arr, int x, int low, int high){
            if(low > high)
                return false;
            int mid = (low + high)/2;
            if(arr[mid] == x){
                    return true;
             }
            else if(arr[mid] < x){
                return BinSearchRecursive(arr, x, mid+1, high );
            }
            else{
                 return BinSearchRecursive(arr, x, low, mid -1 );
            }

        }

        static void Rotate(int[] arr, int num){
            num = num % arr.Length;
            Reverse(arr, 0, arr.Length -1);
            Reverse(arr, 0, num -1);
            Reverse(arr, num , arr.Length -1);
        }

        static void Reverse(int[] arr, int start, int end){
            int temp;
            while(start <= end){
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                end --;
                start ++;

            }
        }

        static int FindMinRotated(int[] arr){

            int low = 0;
            int high = arr.Length -1;

            while(arr[low] > arr[high]){
                int mid = (low + high)/2;
                if(arr[mid] > arr[high]){

                    low = mid +1;
                }
                else{

                    high = mid;
                }

            }
            return arr[low];
        }

        static int GetOccurances(int[] arr, int x){

            return GetOccurances(arr, x, 0, arr.Length -1);
        }
        static int GetOccurances(int[] arr, int x, int low, int high){
            if(high < low)
                return 0;
            if(arr[low] > x)
                return 0;
            if(arr[high] < x)
                return 0;
            if(arr[low] == x && arr[high] == x)
                return high -low +1;

            int mid = (low + high)/2;
            if(arr[mid] == x){
                return 1 + GetOccurances(arr, x, low, mid-1) 
                         + GetOccurances(arr, x, mid +1, high);
            }
            else if(arr[mid] < x){
                return GetOccurances(arr, x, mid +1, high);

            }
            else{
                return GetOccurances(arr,x, low, mid-1);

            }
        }


        static int GetIndexFirstOccurance(int[] arr, int x){

            return GetIndexFirstOccurance(arr, x, 0, arr.Length -1);
        }
        static int GetIndexFirstOccurance(int[] arr, int x, int low, int high){
            if(high < low)
                return -1;
            if(arr[low] > x)
                return -1;
            if(arr[high] < x)
                return -1;
            if(arr[low] == x && arr[high] == x)
                return low;

            int mid = (low + high)/2;
            if(arr[mid] == x){
                return  GetIndexFirstOccurance(arr, x, low, mid);
            }
            else if(arr[mid] < x){
                return GetIndexFirstOccurance(arr, x, mid +1, high);

            }
            else{
                return GetIndexFirstOccurance(arr,x, low, mid-1);
            }
        }

        static void SortArrayWaveForm(int[] arr){
            Array.Sort(arr);
            int temp ;
            for(int i = 0; i < arr.Length -1; i +=2){
                temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }

        }

        static int CeilingSortedArray(int[] arr, int x){
            if(arr[0] > x)
                return 0;
            if(arr[arr.Length -1] < x)
                return -1;

            int ceiling = arr.Length -1;
            CeilingSortedArray(arr, x, 0, arr.Length -1, ref ceiling);
            return ceiling;

        }

        static void Swap(int[] arr, int start, int end){

            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }

        static void CeilingSortedArray(int[] arr, int x, int low, int high, ref int ceiling){
            if(x < arr[low]){
                ceiling = low;
                return;
            }
                
            if(x > arr[high]){

                ceiling = -1;
                return;
            }
            
            int mid = (low + high)/2;
            if(arr[mid] == x){
                ceiling = mid;
                return;
            }
            else if(arr[mid] <x){
                CeilingSortedArray(arr,x, mid+1, high, ref ceiling);
            }
            else{

                ceiling = mid;
                CeilingSortedArray(arr,x, low, mid, ref ceiling);

            }
        }

        static void MoveZeroToEnd(int[] arr){
            int start = 0;
            int end = arr.Length -1;
            while(start <=end){
                if(arr[start] == 0){
                    Swap(arr, start, end);
                    end --;
                }
                else
                    start ++;

            }

        }

        public static void DutchFlag(int[] arr, int x){
            int start = 0;
            int mid = 0;
            int end = arr.Length -1;

            while(mid <= end){

                if(arr[mid] == x){
                    mid ++;
                }
                else if(arr[mid] < x){
                    Swap(arr, start, mid);
                    start ++;
                    mid ++;

                }
                else{
                    Swap(arr, mid, end);
                    end --;
                }
            }

        }

         static int FindMajorityElement(int[] arr){
             int candidate = FindMinRotated(arr);

             int count = 0;

             for(int i = 0; i < arr.Length ; i ++){

                 if(arr[i] == candidate)
                    count ++;
             }
             if(count > arr.Length/2)
                return candidate;

            return int.MinValue;

        }



        static int FindCandidate(int[] arr){

            int candidate = arr[0];
            int count = 1;
            for(int i = 1; i < arr.Length; i ++){

                if(arr[i] != candidate){
                    count --;
                }
                else
                    count ++;

                if(count == 0){

                    candidate = arr[i];
                    count = 1;
                }
            }
            return candidate;

        }




    }
}
