using AexSoft_Test.Data;
using AexSoft_Test.Domain.Interfaces;
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

namespace AexSoft_Test.ViewModels
{
    public class TvShowViewModel : INotifyPropertyChanged
    {
        private readonly IDatabaseService _databaseService;

        public TvShowViewModel(IDatabaseService databaseService)
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
        private int _episodes;
        public int episodes
        {
            get { return _episodes; }
            set
            {
                _episodes = value;
                OnPropertyChanged(nameof(episodes));
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
            var tvShow = await _databaseService.GetTvShowInfoById(AppData.currentShowTimeId);
            if (tvShow == null)
            {
                await Shell.Current.Navigation.PopAsync();
                return;
            }
            title = tvShow.name;
            description = tvShow.description;
            episodes = tvShow.episodes;

            var actorList = await _databaseService.GetActorsByTvShowId(AppData.currentShowTimeId);

            actors = new ObservableCollection<ActorRole>(actorList);
            isLoad = true;
        }
        private bool LoadTvShowItemCommandExecute(object parametr) => true;

        public record class ActorRole(Guid id, string name, string Role);

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
