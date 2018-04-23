using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int val =  findFibTabular(6);
            Console.WriteLine();

            //int[] arr = {10,5,6,-3, 0, 11, 2, 12,4, 7};

            //int max = LongestIncreasingSubSequence(arr);

            //int[] arr = {1,3,5,8,9,2,6,7,6,8,9};

            //int min = GetNumJumps(arr);

            int[] arr = {1,11,2,10,4,5,2,1};

            int max = LargestBittonic(arr);

            Console.WriteLine();
            
        }

        static int findFibRecursive(int num){
            if(num <= 1)
                return num;
            
            return findFibRecursive(num -1) + findFibRecursive(num-2);

        }

        static int findFibTabular(int num){

            int[] arr = new int[num + 1];

            arr[0] = 0;
            arr[1]= 1;

            for(int i = 2; i < num+1; i ++){
                arr[i] = arr[i-1] + arr[i-2];
            }
            return arr[num];
        }

        static int findFibMemo(int num, Dictionary<int, int> dict){

            if(!dict.ContainsKey(num)){

                if(num <= 1)
                    return num;
                
                dict.Add(num, findFibMemo(num-1, dict) +  findFibMemo(num -2, dict));
            }
            return dict[num];
        }

        static int NumWaysToClimb(int num){

            Dictionary<int, int> dict = new Dictionary<int, int>();
            return NumWaysToClimb(num, dict);
        }

        static int  NumWaysToClimb(int num , Dictionary<int, int> dict){

            if(num <0)
                return 0;
            if(num <1)
                return 1;
            else if(dict.ContainsKey(num))
                return dict[num];

            else{
                dict[num] = NumWaysToClimb(num -1, dict) + 
                            NumWaysToClimb(num -2, dict) +
                            NumWaysToClimb(num -3, dict);
                return dict[num];
            }



        }


        static int[] LIS(int[] arr){
             int[] count = new int[arr.Length];

            for(int i = 0 ; i < arr.Length; i ++){
                count[i]=1;
            }

            for(int i = 1; i < arr.Length; i ++){

                for(int j = 0; j < i; j ++){

                    if(arr[i] > arr[j]){
                        if(count[j] + 1 > count[i]){
                            count[i] = count[j] + 1;
                        }
                    }
                }// end of for loop for j
            }// end of for loop for i

            return count;


        }

        static void reverse(int[] arr){

            int start = 0;
            int end = arr.Length -1;
            int temp;
            while(start < end){
                temp = arr[start];
                arr[start]= arr[end];
                arr[end] = temp;

                start ++;
                end --;
            }
        }

        static int LongestIncreasingSubSequence(int[] arr){

            int[] count = new int[arr.Length];
            int[] indexArr = new int[ arr.Length];

            for(int i = 0 ; i < arr.Length; i ++){
                count[i]=1;
                indexArr[i] = i;
            }
            int max = 1;

            for(int i = 1; i < arr.Length; i ++){

                for(int j = 0; j < i; j ++){

                    if(arr[i] > arr[j]){
                        if(count[j] + 1 > count[i]){
                            count[i] = count[j] + 1;
                            indexArr[i] = j;
                            if(max < count[i])
                                max = count[i];
                        }
                    }
                }// end of for loop for j
            }// end of for loop for i

            return max;

        }

        static int GetNumJumps(int[] arr){

            int[] jumps = new int[arr.Length];
            int[] indexArr = new int[arr.Length];

            jumps[0] = 0;
            indexArr[0] = 0;
            for(int i = 1 ; i < arr.Length; i ++){
                jumps[i] = int.MaxValue;
                indexArr[i] = i;
            }

            for(int i =1; i < arr.Length; i ++){

                for(int j = 0; j < i; j ++ ){
                    // if we can jump
                    if(arr[j] + j >= i){
                        if(jumps[i] >  jumps[j] +1){
                            jumps[i] = jumps[j] +1;
                            indexArr[i] = j;
                        }
                    }

                }// end of loop for j
            }// end of loop for i

            return jumps[arr.Length -1];


        }

        static int LargestBittonic(int[] arr){

            int[] lis = LIS(arr);
            reverse(arr);
            int[] lds = LIS(arr);
            reverse(lds);

            int max = 0;
            for(int i = 0 ; i < arr.Length; i ++){
                if(lis[i] + lds[i] -1 > max)
                    max = lis[i] + lds[i] -1;
            }

            return max;
        }



        
    }
}
