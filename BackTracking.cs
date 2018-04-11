using System;
using System.Text;

namespace Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSubsets("ABC");
            Console.WriteLine("Hello World!");
        }

        static void GenerateBinSequence(int n){
            if(n <= 0)
                return;
            int[] result = new int[n];
            int current = 0;
            GenerateBinSequence(result, current);
        }

        static void GenerateBinSequence(int[] result, int current ){

            if(result.Length == current){
                PrintArray(result);
                return;

            }

            for(int i = 0  ; i < 2; i ++){
                result[current] = i;
                GenerateBinSequence(result, current +1 );

            }
        }

        static void GenerateMarySequence(int n, int m){
            if(n <= 0)
                return;
            int[] result = new int[n];
            int current = 0;
            GenerateMarySequence(result, current, m);
        }

        static void GenerateMarySequence(int[] result, int current, int m ){

            if(result.Length == current){
                PrintArray(result);
                return;

            }

            for(int i = 0  ; i < m; i ++){
                result[current] = i;
                GenerateMarySequence(result, current +1, m );

            }
        }





        static void PrintArray(int[] result){

            for(int i = 0 ; i < result.Length; i ++){
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();
        }

        #region Combinations
        static void Combinations(string str, int n){
            if(str.Length == 0 || n <= 0)
                return;
            int[] result = new int[n];

            Combinations(result, str, 0, n);

        }

        static void Combinations(int[] result, string  str,int current,  int n){
            if(result.Length == current){
                PrintCombinations(result, str);
                return;

            }

            for(int i = 0 ; i < str.Length; i ++){
                result[current] = i;
                Combinations(result, str, current +1, n);

            }

        }

        static void PrintCombinations(int[] result, string str){

            for(int i = 0 ; i < result.Length; i ++){
                Console.Write(str[result[i]] +  " ");

            }
            Console.WriteLine();
        }

        #endregion

        #region Permutations
        static void Permutation(string str){
            if(str.Length == 0)
                return;
            int[] result = new int[str.Length];
            int current = 0;
            Permutation(result, current, str);

        }

        static void Permutation(int[] result, int current, string str){

            if(current == result.Length){
                PrintCombinations(result, str);
                return;
            }

            for(int i = 0 ; i < result.Length; i ++){
                if(IsValid(result, current, i)){
                    result[current]= i;
                    Permutation(result, current +1, str);
                }

            }
        }

        static bool IsValid(int[] result, int current, int i){

            for(int n =0; n < current; n ++){
                if(result[n] == i)
                    return  false;
            }
            return true;
        }



        #endregion

        #region Generate Subsets

        static void GenerateSubsets(string str){

            if(str.Length == 0)
                return;
            int[] result = new int[str.Length];
            int current =0;
            GenerateSubsets(result, current, str);

        }

        static void GenerateSubsets(int[] result, int current, string str){
            if(current == result.Length){
                PrintSubsets(result, str);
                return;
            }
            for(int i = 0 ; i < 2; i ++){
                result[current]= i;
                GenerateSubsets(result, current +1, str);
            }

        }

        static void PrintSubsets(int[] result, string str){
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for(int i = 0 ; i < result.Length; i ++){
                if(result[i] == 1){
                    sb.Append(str[i]);
                }
            }
            sb.Append("}");
            Console.WriteLine(sb.ToString());
            
        }


        #endregion


    }
}
