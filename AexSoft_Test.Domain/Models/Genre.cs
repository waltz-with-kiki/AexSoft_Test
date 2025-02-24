using AexSoft_Test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Domain.Models
{
    public class Genre : IShowTime
    {
        public Guid id { get; set; }
        public string name { get; set; } = "";
        public string? description { get; set; }
        public virtual List<Movie>? Movies { get; set; } = new List<Movie>();
        public virtual List<TVShow>? TVShows { get; set; } = new List<TVShow>();
    }
}
