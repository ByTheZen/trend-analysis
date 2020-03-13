using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TextAnalysis.Models
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<string> Text { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        //public Dictionary<string, int> WordFrequency { get; set; }
        public int Sentiment { get; set; }



    }
}
