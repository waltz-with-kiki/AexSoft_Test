using AexSoft_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.Services
{
    public class ViewModelLocator
    {
        public MainPageViewModel Main => App.services.GetRequiredService<MainPageViewModel>();
        public SearchLayoutViewModel SearchLayout => App.services.GetRequiredService<SearchLayoutViewModel>();
    }
}
