using AexSoft_Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Domain.Interfaces
{
    //Объединение сериалов и фильмов
    public interface ICineVerse : IShowTime
    {
        public List<Genre>? Genres { get; set; }
    }
}
