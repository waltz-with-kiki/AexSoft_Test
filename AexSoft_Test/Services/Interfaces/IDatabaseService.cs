using AexSoft_Test.Domain.Interfaces;
using AexSoft_Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AexSoft_Test.ViewModels.TvShowViewModel;

namespace AexSoft_Test.Services.Interfaces
{
    public interface IDatabaseService
    {
        public Task<List<IShowTime>?> SearchAsync(string searchReq);
        public Task<TVShow?> GetTvShowInfoById(string id);
        public Task<Movie?> GetMovieInfoById(string id);
        public Task<Actor?> GetActorInfoById(string id);
        public Task<Genre?> GetGenreInfoById(string id);
        public Task<List<ActorRole>> GetActorsByTvShowId(string tvShowId);
        public Task<List<ActorRole>> GetActorsByMovieId(string MovieId);
    }
}
