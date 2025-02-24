using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Data
{
    //для глобальных переменных
    public static class Immutable
    {
        public static string dbpath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
    }
}
