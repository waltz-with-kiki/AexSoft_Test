using AexSoft_Test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Domain.Models
{
    public class TVShow : ICineVerse
    {
        public Guid id { get; set; }
        public string name { get; set; } = "";
        public string? description { get; set; }
        //демонстрация разницы сериалов и фильмов
        public int episodes { get; set; }
        public virtual List<Genre>? Genres { get; set; } = new List<Genre>();
        public virtual List<ActorTVShow>? Actors { get; set; } = new List<ActorTVShow>();
    }
}
