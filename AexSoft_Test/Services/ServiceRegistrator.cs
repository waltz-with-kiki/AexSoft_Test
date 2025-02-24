using AexSoft_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Services
{
    static class ServiceRegistrator
    {
        //регистрация сервисов
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IDatabaseService, DatabaseService>()
            ;
    }
}
