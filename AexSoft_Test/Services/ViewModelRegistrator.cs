using AexSoft_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Services
{
    public static class ViewModelRegistrator
    {
        //регистрация постоянных ViewModels
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
           .AddSingleton<MainPageViewModel>()
            .AddSingleton<SearchLayoutViewModel>()
        ;
    }
}
