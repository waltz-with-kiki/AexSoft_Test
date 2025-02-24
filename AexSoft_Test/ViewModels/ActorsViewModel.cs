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
    // реализуем интерфейс для отслеживания изменений
    public class ActorsViewModel : INotifyPropertyChanged
    {
        //DI service
        private readonly IDatabaseService _databaseService;

        public ActorsViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        // объекты будут привязаны через Binding во View, изменения будут отображаться
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

        //Используем команды для избежания async void
        private IAsyncCommand<object> _loadTvShowItem = null!;
        public IAsyncCommand<object> loadTvShowItem => _loadTvShowItem ??=
            new AsyncCommand<object>(LoadTvShowItemCommandExecuted,
                                     LoadTvShowItemCommandExecute);

        private async Task LoadTvShowItemCommandExecuted(object parametr)
        {
            var actor = await _databaseService.GetActorInfoById(AppData.currentShowTimeId);
            if (actor != null)
            {
                title = actor.name;
                description = actor.description;
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
