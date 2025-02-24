using AexSoft_Test.Data;
using AexSoft_Test.Domain.Interfaces;
using AexSoft_Test.Domain.Models;
using AexSoft_Test.Services;
using AexSoft_Test.Services.Interfaces;
using AexSoft_Test.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class SearchLayoutViewModel :  INotifyPropertyChanged 
    {
        private readonly IDatabaseService _databaseService;
        private CancellationTokenSource _searchDelayToken = null!;


        public SearchLayoutViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        private ObservableCollection<IShowTime> _searchResults = new();
        public ObservableCollection<IShowTime> searchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(searchResults));
            }
        }

        private string _searchReq = "";
        public string searchReq
        {
            get { return _searchReq; }
            set
            {
                if (_searchReq != value)
                {
                    _searchReq = value;
                    OnPropertyChanged(nameof(searchReq));

                    _searchDelayToken?.Cancel();
                    _searchDelayToken = new CancellationTokenSource();
                    _ = SearchCollection(_searchDelayToken.Token);
                }
            }
        }

        private bool _isSearchResultsVisible;
        public bool IsSearchResultsVisible
        {
            get => _isSearchResultsVisible;
            set
            {
                if (_isSearchResultsVisible != value)
                {
                    _isSearchResultsVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task SearchCollection(CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(searchReq))
            {
                IsSearchResultsVisible = false;
                searchResults.Clear();
                return;
            }

            try
            {
                await Task.Delay(500, token);

                var result = await _databaseService.SearchAsync(searchReq);
                if (!token.IsCancellationRequested)
                {
                    searchResults.Clear();
                    foreach (var item in result)
                    {
                        searchResults.Add(item);
                    }
                }
                if (searchResults.Count > 0)
                {
                    IsSearchResultsVisible = true;
                }
            }
            catch (Exception ex)
            {
                //логирование ex
            }
        }


        private IAsyncCommand<IShowTime> _itemSelected = null!;
        public IAsyncCommand<IShowTime> itemSelected => _itemSelected ??=
            new AsyncCommand<IShowTime>(OnLoadTvShowItemCommandExecuted,
                                     CanLoadTvShowItemCommandExecute);

        private async Task OnLoadTvShowItemCommandExecuted(IShowTime selectedItem)
        {
            if (selectedItem == null)
                return;
            AppData.currentShowTimeId = selectedItem.id.ToString();
            var type = selectedItem.GetType();
            if (type == typeof(TVShow))
            {
                TvShowPage tvShopPage = new TvShowPage();
                await Shell.Current.Navigation.PushAsync(tvShopPage);
            }
            else if (type == typeof(Actor))
            {
                ActorPage actorPage = new ActorPage();
                await Shell.Current.Navigation.PushAsync(actorPage);
            }
            else if (type == typeof(Genre))
            {
                GenrePage genrePage = new GenrePage();
                await Shell.Current.Navigation.PushAsync(genrePage);
            }
            else if (type == typeof(Movie))
            {
                MoviePage moviePage = new MoviePage();
                await Shell.Current.Navigation.PushAsync(moviePage);
            }
        }
        private bool CanLoadTvShowItemCommandExecute(IShowTime parametr) => true;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
