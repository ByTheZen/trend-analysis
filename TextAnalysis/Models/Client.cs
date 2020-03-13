using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalysis.Models
{
    public class Client
    {

        public string Result;
        public Client()
        {
            SentimentInterface nyTimes = new NyTimesImplementation();
            Result = nyTimes.Result;
        }

    }
}
