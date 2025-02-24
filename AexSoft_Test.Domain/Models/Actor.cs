using AexSoft_Test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Domain.Models
{
    public class Actor : IShowTime
    {
        public Guid id { get; set; }
        public string name { get; set; } = "";
        public string? description { get; set; }
        public virtual List<ActorMovie>? Movies { get; set; } = new List<ActorMovie>();
        public virtual List<ActorTVShow>? TVShows { get; set; } = new List<ActorTVShow>();
    }
}
