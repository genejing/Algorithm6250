using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SearchSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = {1,5,3,1,6,1,0,5,1,2,6,5};
            //SubArrayWithGivenSum(arr, 11);

            //string str = ReverseSentence("This is a Sentence");

            int[] arr1 = {1,5,6,8,10, 12};
            int[] arr2 = {2,3,5,7,11, 15};
            int median = GetMedian(arr1, arr2, 0, arr1.Length, 0, arr2.Length );
            Console.WriteLine("Hello World!");
        }

        static bool IsRotated(string str1, string str2){
            if(str1.Length != str2.Length)
                return false;
            str2 += str2;

            if(!str2.Contains(str1))
                return false;
            
            return true;

        }

        static string ReverseSentence(string str){

            if(string.IsNullOrEmpty(str) || str.Length ==1)
                return str;

            char[] arr = str.ToCharArray();

            Reverse(arr, 0, arr.Length -1);
            int start =0;
            for(int i = 0 ; i < arr.Length ; i++){

                if(arr[i] == ' '){
                    Reverse(arr, start, i-1);
                    start = i+1;

                }

                

            }

            if(start != arr.Length -1){

                    Reverse(arr, start, arr.Length-1);
            }

            return arr.ToString();
        }

        static int EquilibriumPoint(int[] arr){

            int sum = 0; 
            int leftSum = 0;

            for(int i = 0 ; i < arr.Length ; i ++)
                sum += arr[i];
            for(int i = 0; i < arr.Length ; i ++){
                sum = sum - arr[i];

                if(leftSum == sum)
                    return i;
                leftSum += arr[i];

            }

            return -1;
        }


        static void Reverse(char[] arr, int start, int end){
            if(start >= end)
                return;

            while(start < end){
                char temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;

                start ++;
                end--;

            }

        }


        static int FindMedian(int[] arr1, int[] arr2, int ptr1, int ptr2, int count){

            if(count == arr1.Length -1)
                return ( (arr1[ptr1] + arr2[ptr2])/2 );
            count ++;
            if(arr1[ptr1] < arr2[ptr2]){
                ptr1 ++;

                return FindMedian(arr1, arr2, ptr1, ptr2, count);

            }
            else{
                ptr2 ++;
                return FindMedian(arr1, arr2, ptr1, ptr2, count);
            }
        }


        static void CheckIfSumEqualsRestExtraMemNoDupe(int[] arr){
            int sum = 0;
           Array.Sort(arr);
           for(int i = 0; i < arr.Length; i ++){
               sum += arr[i];
           }
           sum = sum/2;

           HashSet<int> set = new HashSet<int>();

           for(int i = 0 ;i < arr.Length; i ++){

               int val = sum - arr[i];
               if( set.Contains(val)){
                   Console.WriteLine("Found Values = " + arr[i] + "," + val );
                   return;

               }
               if(!set.Contains(arr[i])){
                   set.Add(arr[i]);
               }
           }

           Console.WriteLine("Not Found");

         }

         static bool IsAnagram (string str1, string str2){

             if(str1.Length != str2.Length)
                return false;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach(char ch in str1){

                if(!dict.ContainsKey (ch))
                    dict.Add(ch, 1);
                else
                    dict[ch] ++;
            }

            foreach(char ch in str2){

                if(!dict.ContainsKey (ch))
                    return false;
                else
                    dict[ch] --;
            }

            foreach(KeyValuePair<char, int> kvPair in dict){

                if(kvPair.Value != 0)
                    return false;
            }

            return true;


         }

         static string ReplaceSpace(string str){

             StringBuilder sb = new StringBuilder();

             for(int i = 0 ; i < str.Length; i ++){
                 if(str[i] == ' ' )
                    sb.Append("%20");
                else
                    sb.Append(str[i]);

             }

             return sb.ToString();
         }

         static string Compress(string str){
             if(string.IsNullOrEmpty(str) || str.Length ==1)
                return str;

            StringBuilder sb = new StringBuilder();
            char current = str[0];
            int count = 1;
            for(int i = 1; i < str.Length ; i ++){

                if(str[i] != current){
                    sb.Append(current + count.ToString());
                    current = str[i];
                    count =1;

                }
                else
                    count++;
            }

            sb.Append(current + count.ToString());

            if(sb.ToString().Length >= str.Length)
                return str;
            
            return sb.ToString();
            

         }

        static void CheckIfSumEqualsRest(int[] arr){
           int sum = 0;
           Array.Sort(arr);
           for(int i = 0; i < arr.Length; i ++){
               sum += arr[i];
           }

           int low =0;
           int high = arr.Length -1;
           while(low < high){

               if(arr[low] + arr[high] == sum/2){

                   Console.WriteLine("Found Values = " + arr[low] + "," + arr[high]);
                   return;
               }
               else if(arr[low] + arr[high] < sum/2)
                low ++;
               else
                high --;
               
           }
           Console.WriteLine("Not found");

       }

        static int Median(int[] arr , int start, int end){
            int mid = (start + end)/2;
            if( (end -start)%2 == 0)
                return arr[mid];
             else
                return arr[mid-1];

        }

        static int GetMedian(int[] arr1, int[] arr2, int start1, int end1, int start2, int end2){
            if(end1 - start1 == 1 && end2-start2 ==1){

                int start = Math.Max(arr1[start1], arr2[start2]);
                int end = Math.Min(arr1[end1], arr2[end2]) ;

                return  (start + end)/2;
            }

            int median1 = Median(arr1, start1, end1);
            int median2 = Median(arr2, start2, end2);

            if(median1 < median2){

                start1 = (start1 + end1)/2;
                end2 = (start2 + end2)/2;
            }else{
                end1 = (start1 + end1)/2;
                start2 = (start2 + end2)/2;

            }

            return GetMedian(arr1, arr2, start1, end1, start2, end2);
        }



       private static void SubArrayWithGivenSum(int[] arr, int sum){

           int currentSum = 0;
           int start = 0;
           for(int i = 0 ; i < arr.Length; i ++){

               while(currentSum > sum && start < arr.Length -1 ){
                   currentSum = currentSum - arr[start];
                   start++;
               }

               if(currentSum == sum){
                   Console.WriteLine("Sub Array found between index: "  + start + ", " +i);
                   return;
               }
               currentSum += arr[i];
           }
       }
    }
}
