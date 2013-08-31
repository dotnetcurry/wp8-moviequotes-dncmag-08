using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieQuotes
{
    /// <summary>
    /// MovieQuotes Class to represent MovieQuote from XML file
    /// </summary>
    public class MovieQuote
    {
        public string Text { get; set; }
        public string Movie { get; set; }
        public string ImdbUrl { get; set; }
    }
    /// <summary>
    /// Reader Class to read quotes from XML file
    /// </summary>
    public class QuotesReader
    {
        public List<MovieQuote> GetMovieQuotes()
        {
            var xdoc = XDocument.Load("MovieQuotes.xml");
            var quotesList = from x in xdoc.Descendants("Quote")
                select new MovieQuote
                {
                    Text = x.Element("Text").Value,
                    Movie = x.Element("Movie").Value,
                    ImdbUrl = x.Element("IMDB").Value
                };
            return quotesList.ToList();
        }
    }
    /// <summary>
    /// Extension Class to load Random/Next Quote
    /// </summary>
    public static class Extenders
    {
        public static T GetSingleRandom<T>(this IEnumerable<T> target)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int position = r.Next(target.Count<T>());
            return target.ElementAt<T>(position);
        }
    }
}
