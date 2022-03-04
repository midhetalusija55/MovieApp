using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Common.Models
{
    public class MovieCall
    {
        public string Type { set; get; }
        public int Page { set; get; }

        public MovieCall(string type, int page)
        {
            Type = type;
            Page = page;
        }
    }
}
