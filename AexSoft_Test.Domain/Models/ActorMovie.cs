using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Domain.Models
{
    public class ActorMovie
    {
        public Guid ActorId { get; set; }
        public virtual Actor Actor { get; set; } = null!;

        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;

        public string Role { get; set; } = "";
    }
}
