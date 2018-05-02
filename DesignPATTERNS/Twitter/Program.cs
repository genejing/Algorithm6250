using System;
using System.Threading;

namespace Twitter
{
    class Program
    {
        static Person trump;
        static Person hillary ;

        private static void TweetFunc(object obj){
            Random rand = new Random();

            int wait = 0;

            while(true){
                wait = rand.Next(3000, 10000);
                Thread.Sleep(wait);
                trump.SendTweet("Some Random Tweet " + wait.ToString());

                wait = rand.Next(2000, 10000);
                Thread.Sleep(wait);
                hillary.SendTweet("Some more meaninless Random Tweet " + wait.ToString());


            }

        }

        static void Main(string[] args)
        {
             trump = new Person("@Trump", 70);
             hillary = new Person("@Hillary", 68);

             Person Ashish = new Person("@Ashish", 16);
             Person camille = new Person("@Camille", 16);
             Person Harsh = new Person("@Harsh", 16);
             Person bharti = new Person("@Bharti", 16);

             Ashish.Follow(trump);
             Ashish.Follow(hillary);

             camille.Follow(hillary);

             Harsh.Follow(trump);
             bharti.Follow(trump);
             bharti.Follow(hillary);


            Thread th = new Thread( new ParameterizedThreadStart ( TweetFunc));
            th.Start("ABC");

             while(true){

                Console.WriteLine("Main Function");

                Thread.Sleep(5000);
             }

        }
    }
}
