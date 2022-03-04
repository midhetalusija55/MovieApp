using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Movie.Common.Models
{
    class MovieResponse
    {
        public int page { get; set; }
        public ObservableCollection<Movies> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
        public string status_message { get; set; }
    }
}
