using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace TextAnalysis.Models
{
    public class RssReader
    {
        private IEnumerable<SyndicationItem> Feed;
        public List<string> articles;
        private List<string> _keyWords;
        private string _url;

        public RssReader(List<string> keyWords, string url)
        {
            _keyWords = keyWords;
            _url = url;
        }

        public bool Read()
        {
            var reader = XmlReader.Create(_url);
            var feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                if (ItemContainsKeyword(item))
                {
                    articles.Add(GetFirstLink(item.Links));
                }
            }

            return articles.Count > 0;
        }

        private bool ItemContainsKeyword(SyndicationItem item)
        {
            foreach (string keyword in _keyWords)
            {
                if (item.Title.Text.Contains(keyword) || item.Summary.Text.Contains(keyword))
                {
                    return true;
                }
            }
            return false;
        }

        private string GetFirstLink(Collection<SyndicationLink> links)
        {
            string uri = string.Empty;
            foreach (SyndicationLink link in links)
            {
                uri = link.Uri.ToString();
                break;
            }

            return uri;
        }




    }
}
