using AexSoft_Test.Data;
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
    public class GenreViewModel :INotifyPropertyChanged
    {
        private readonly IDatabaseService _databaseService;

        public GenreViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        private string _title = "";
        public string title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(title));
            }
        }
        private string? _description;
        public string? description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(description));
            }
        }

        private bool _isLoad = false;
        public bool isLoad
        {
            get { return _isLoad; }
            set
            {
                _isLoad = value;
                OnPropertyChanged(nameof(isLoad));
            }
        }


        private IAsyncCommand<object> _loadTvShowItem = null!;
        public IAsyncCommand<object> loadTvShowItem => _loadTvShowItem ??=
            new AsyncCommand<object>(LoadTvShowItemCommandExecuted,
                                     LoadTvShowItemCommandExecute);

        private async Task LoadTvShowItemCommandExecuted(object parametr)
        {
            var genre = await _databaseService.GetGenreInfoById(AppData.currentShowTimeId);
            if (genre != null)
            {
                title = genre.name;
                description = genre.description;
                isLoad = true;
            }
            else
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }
        private bool LoadTvShowItemCommandExecute(object parametr) => true;


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
