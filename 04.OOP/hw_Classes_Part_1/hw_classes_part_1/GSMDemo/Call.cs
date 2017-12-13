using System;
namespace GSMDemo
{
    public class Call
    {
        public Call(string date, string time, string dialedNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public string Date { get; set; }
        public string Time { get; set; }
        public string DialedNumber { get; set; }
        public int Duration { get; set; }


    }
}
