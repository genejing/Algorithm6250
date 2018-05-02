using System;
using System.Collections.Generic;

class Person{

    public string  name { get; set; }

    public int age { get; set; }

    public Person(string name, int age){
        this.name = name;
        this.age = age;
    }

    public event EventHandler<TweetMessage> tweetEvent;

    public void SendTweet(string message){

        TweetMessage tweet = new TweetMessage(message);

        if(tweetEvent != null){
            tweetEvent(this, tweet);
        }
    }

    public void PrintTweet(object sender, TweetMessage msg){
        Person tweeter = (Person) sender;
        Console.WriteLine(this.name +":" + tweeter.name + " Tweeted " + msg.message + " at " + msg.time.ToString());


    }
    public void Follow(Person person){
        person.tweetEvent += PrintTweet;
    }

    public void UnFollow(Person person){
        person.tweetEvent -= PrintTweet;
    }

}