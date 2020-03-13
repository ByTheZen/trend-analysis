using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using TextAnalysisML.Model;

namespace TextAnalysis.Models
{
    public class NyTimesImplementation : SentimentInterface
    {

        private Article _article;
        public override void GetData()
        {
            string url = @"https://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml";
            Result = string.Empty;
            var rssReader = new RssReader( new List<string> { "Coronavirus", "coronavirus" }, url);
            if (rssReader.Read())
            {
                foreach (string uri in rssReader.articles)
                {
                    string.Concat(Result, uri);
                }
            }
        }

        public override void FillSentiment()
        {
            int totalSentiment = 0;
            ModelOutput result;
            var input = new ModelInput();
            foreach (string line in _article.Text)
            {
                input.Comment = line;
                result = ConsumeModel.Predict(input);
                totalSentiment += result.Prediction ? 1 : 0;
            }

            _article.Sentiment = totalSentiment / _article.Text.Count;
        }
    }
}
