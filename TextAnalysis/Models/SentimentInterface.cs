using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalysis.Models
{
    public abstract class SentimentInterface
    {
        public int Sentiment;
        public int AverageSentiment;
        public string Result;

        public abstract void GetData();
        public abstract void FillSentiment();       
    }
}
