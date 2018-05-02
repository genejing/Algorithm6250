

using System;

class TweetMessage: EventArgs{
    public string message { get; set; }
    public DateTime time { get; set; }

    public TweetMessage (string message ){

        this.message = message;
        this.time = DateTime.Now;
    }

}