using AexSoft_Test.DAL.Context;
using AexSoft_Test.Domain.Interfaces;
using AexSoft_Test.Domain.Models;
using AexSoft_Test.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AexSoft_Test.ViewModels.TvShowViewModel;

namespace AexSoft_Test.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ApplicationDbContext _db;
        public DatabaseService(ApplicationDbContext db)
        {
            _db = db;
        }

        /*
            SELECT TOP 1 * 
            FROM Actors 
            WHERE id = @guid
         */
        //AsNoTracking т.к. не планируем изменять объекты
        //try catch везде используем т.к. обращение к базе
        public async Task<Actor?> GetActorInfoById(string id)
        {
            try
            {
                if (Guid.TryParse(id, out var guid) && guid != Guid.Empty)
                    return await _db.Actors.Where(x => x.id == guid).AsNoTracking().FirstOrDefaultAsync();
                else return null!;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Genre?> GetGenreInfoById(string id)
        {
            try
            {
                if (Guid.TryParse(id, out var guid) && guid != Guid.Empty)
                    return await _db.Genres.Where(x => x.id == guid).AsNoTracking().FirstOrDefaultAsync();
                else return null!;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Movie?> GetMovieInfoById(string id)
        {
            try
            {
                if (Guid.TryParse(id, out var guid) && guid != Guid.Empty)
                    return await _db.Movies.Where(x => x.id == guid).Include(x => x.Actors).AsNoTracking().FirstOrDefaultAsync();
                else return null!;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<TVShow?> GetTvShowInfoById(string id)
        {
            try
            {
                if (Guid.TryParse(id, out var guid) && guid != Guid.Empty)
                    return await _db.TVShows.Where(x => x.id == guid).Include(x => x.Actors).AsNoTracking().FirstOrDefaultAsync();
                else return null!;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<List<ActorRole>> GetActorsByTvShowId(string tvShowId)
        {
            var tvShow = await GetTvShowInfoById(tvShowId);
            if (tvShow == null) return new List<ActorRole>();

            var tasks = tvShow.Actors
                .Select(async item =>
                {
                    var actor = await GetActorInfoById(item.ActorId.ToString());
                    return new ActorRole(item.ActorId, actor?.name ?? "", item.Role);
                });

            return (await Task.WhenAll(tasks)).ToList();
        }

        /*
         *SELECT a.Id, a.Name, ma.Role
            FROM Actors a
            JOIN ActorMovie ma ON a.Id = ma.ActorId
            WHERE ma.MovieId = @MovieId;
         */
        public async Task<List<ActorRole>> GetActorsByMovieId(string MovieId)
        {
            var movie = await GetMovieInfoById(MovieId);
            if (movie == null) return new List<ActorRole>();

            var tasks = movie.Actors
                .Select(async item =>
                {
                    var actor = await GetActorInfoById(item.ActorId.ToString());
                    return new ActorRole(item.ActorId, actor?.name ?? "", item.Role);
                });

            return (await Task.WhenAll(tasks)).ToList();
        }

        /*
            SELECT * 
            FROM TVShows 
            WHERE LOWER(name) LIKE '%' + @searchReq + '%'
         */
        //Объёденение всех объектов, для поиска нужного фильма, сериала, жанра и т.д
        public async Task<List<IShowTime>?> SearchAsync(string searchReq)
        {
            try
            {
                List<IShowTime> cineVerses = new List<IShowTime>();
                var genres = await _db.Genres.Where(x => x.name.ToLower().Contains(searchReq)).AsNoTracking().FirstOrDefaultAsync();
                var tvShows = await _db.TVShows.Where(x => x.name.ToLower().Contains(searchReq)).AsNoTracking().ToListAsync();
                var movies = await _db.Movies.Where(x => x.name.ToLower().Contains(searchReq)).AsNoTracking().ToListAsync();
                var actors = await _db.Actors.Where(x => x.name.ToLower().Contains(searchReq)).AsNoTracking().ToListAsync();
                if(genres != null)
                {
                    cineVerses.Add(genres);
                }
                if(tvShows.Count != 0)
                {
                    cineVerses.AddRange(tvShows);
                }
                if(movies.Count != 0)
                {
                    cineVerses.AddRange(movies);
                }
                if(actors.Count != 0)
                {
                    cineVerses.AddRange(actors);
                }

                return cineVerses;
                }
            catch (Exception)
            {
                //логирование ex
                return null; 
            }
        }

        /*
         
        public async Task<List<IShowTime>> SearchAsync(string searchReq)
        {
            var a = _db.Actors.FirstOrDefault();
            var b = _db.Genres.FirstOrDefault();
            var c = _db.TVShows.FirstOrDefault();

            List<IShowTime> cineVerses = new List<IShowTime>();

            cineVerses.AddRange(await _db.TVShows.AsNoTracking().ToListAsync());
            cineVerses.AddRange(await _db.Movies.AsNoTracking().ToListAsync());
            cineVerses.Add(a);

            return cineVerses;
        }
         */
    }
}
