using AexSoft_Test.Data;
using AexSoft_Test.Domain.Models;
using AexSoft_Test.Services;
using AexSoft_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static AexSoft_Test.ViewModels.TvShowViewModel;

namespace AexSoft_Test.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private readonly IDatabaseService _databaseService;

        public MovieViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        private ObservableCollection<ActorRole> _actors = new();
        public ObservableCollection<ActorRole> actors
        {
            get { return _actors; }
            set
            {
                _actors = value;
                OnPropertyChanged(nameof(actors));
            }
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
        private string? _duration;
        public string? duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(duration));
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
            var movie = await _databaseService.GetMovieInfoById(AppData.currentShowTimeId);
            if (movie == null)
            {
                await Shell.Current.Navigation.PopAsync();
                return;
            }
            title = movie.name;
            description = movie.description;
            duration = movie.Duration;
            var actorList = await _databaseService.GetActorsByMovieId(AppData.currentShowTimeId);

            actors = new ObservableCollection<ActorRole>(actorList);
            isLoad = true;
        }
        private bool LoadTvShowItemCommandExecute(object parametr) => true;


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
