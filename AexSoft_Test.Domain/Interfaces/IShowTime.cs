using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Domain.Interfaces
{
    //Объединение всех моделей для поиска
    public interface IShowTime
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
    }
}
