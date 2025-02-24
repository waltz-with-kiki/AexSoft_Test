using AexSoft_Test.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            DesignTimeDbContextFactory contex = new DesignTimeDbContextFactory();
            var a = contex.CreateDbContext(args);
            a.Database.Migrate();
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite("Data Source=app.db");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

    }
}