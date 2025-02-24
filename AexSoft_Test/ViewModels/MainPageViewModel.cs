using AexSoft_Test.Services;
using AexSoft_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.ViewModels
{
    public class MainPageViewModel
    {
        public string MainContent { get; set; } = "Добро пожаловать на главную страницу";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
