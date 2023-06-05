using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traine_MovieDB
{
    public class Movie
    {
        [Name("title")]
        public string Title { get; set; }

        [Name("rating")]
        public string Rating { get; set; }

        [Name("year")]
        public string Year { get; set; }

        [Name("users_rating")]
        public string Users_Rating { get; set; }

        [Name("votes")]
        public string Votes { get; set; }

        [Name("metascore")]
        public string Metascore { get; set; }

        [Name("img_url")]
        public string Img_Url { get; set; }

        [Name("countries")]
        public string Countries { get; set; }

        [Name("languages")]
        public string Languages { get; set; }

        [Name("actors")]
        public string Actors { get; set; }

        [Name("genre")]
        public string Genre { get; set; }

        [Name("tagline")]
        public string Tagline { get; set; }

        [Name("description")]
        public string Description { get; set; }

        [Name("directors")]
        public string Directors { get; set; }

        [Name("runtime")]
        public string Runtime { get; set; }

        [Name("imdb_url")]
        public string Imdb_Url { get; set; }
    }
}
