using AexSoft_Test.DAL.Context;
using AexSoft_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AexSoft_Test
{
    public partial class App : Application
    {
        public static IServiceProvider services { get; private set; }
        public App(IServiceProvider _services)
        {
            InitializeComponent();
            services = _services;
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            //задали корневой
            await Shell.Current.GoToAsync("//MainPage");
            await EnsureDatabaseCreated();
            base.OnStart();
        }

        private async Task EnsureDatabaseCreated()
        {
            var dbContext = services.GetRequiredService<ApplicationDbContext>();
            //await dbContext.Database.EnsureDeletedAsync();
            //обновление базы через миграции
            await dbContext.Database.MigrateAsync();
            var actorlist = await dbContext.Actors.AsNoTracking().ToListAsync();
            //Mock объекты для демонстрации работы
            if(actorlist.Count == 0)
            {
                await DbInit();
            }
        }

        private async Task DbInit()
        {
            var dbContext = services.GetRequiredService<ApplicationDbContext>();
            await dbContext.Genres.AddAsync(new Genre { id = Guid.NewGuid(), name = "Drama", description = "The drama genre is a broad category that features stories portraying human experiences, emotions, conflicts, and relationships in a realistic and emotionally impactful way. Dramas delve into the complexities of human life, often exploring themes of love, loss, morality, societal issues, personal growth, with the aim to evoke an emotional response from the audience by presenting relatable and thought-provoking stories." });
            await dbContext.Genres.AddAsync(new Genre { id = Guid.NewGuid(), name = "Romance", description = "The romance genre features the theme of romantic relationships and emotional connections between characters. These stories focus on the development of love, desire, and intimacy between protagonists, often exploring the challenges, conflicts, and triumphs that arise in their relationships." });
            await dbContext.Genres.AddAsync(new Genre { id = Guid.NewGuid(), name = "Thriller", description = "The thriller genre features suspense, tension, and excitement. These stories are known for keeping audiences on the edge of their seats and delivering intense emotional experiences by revolving around high-stakes situations, dangerous conflicts, and the constant anticipation of unexpected events." });
            await dbContext.Genres.AddAsync(new Genre { id = Guid.NewGuid(), name = "Comedy", description = "The comedy genre refers to a category of entertainment that aims to amuse and entertain audiences by using humor, wit, and comedic situations. Comedies are created with the primary intention of eliciting laughter and providing lighthearted enjoyment. They encompass a wide range of styles, tones, and themes, appealing to various tastes and audiences." });
            await dbContext.SaveChangesAsync();

            var Drama = await dbContext.Genres.Where(x => x.name == "Drama").FirstOrDefaultAsync();
            var Thriller = await dbContext.Genres.Where(x => x.name == "Thriller").FirstOrDefaultAsync();
            var Romance = await dbContext.Genres.Where(x => x.name == "Romance").FirstOrDefaultAsync();
            var Comedy = await dbContext.Genres.Where(x => x.name == "Comedy").FirstOrDefaultAsync();

            await dbContext.Actors.AddAsync(new Actor { id = Guid.NewGuid(), name = "Anthony Hopkins", description = "Anthony Hopkins was born on December 31, 1937, in Margam, Wales, to Muriel Anne (Yeats) and Richard Arthur Hopkins, a baker. His parents were both of half Welsh and half English descent. Influenced by Richard Burton, he decided to study at College of Music and Drama and graduated in 1957. In 1965, he moved to London and joined the National Theatre, invited by Laurence Olivier, who could see the talent in Hopkins. In 1967, he made his first film for television, A Flea in Her Ear (1967)." });
            await dbContext.Actors.AddAsync(new Actor { id = Guid.NewGuid(), name = "Christopher Walken", description = "Lead and supporting actor of the American stage and films, with sandy colored hair, and pale complexion. He won an Oscar as Best Supporting Actor for his performance in Охотник на оленей (1978), and has been seen in mostly character roles, often portraying psychologically unstable individuals, though that generalization would not do justice to Walken's depth and breadth of performances." });
            await dbContext.SaveChangesAsync();

            List<Genre> severanceGenres = new List<Genre>();
            if (Drama != null)
            {
                severanceGenres.Add(Drama);
            }
            if (Thriller != null)
            {
                severanceGenres.Add(Thriller);
            }
            await dbContext.TVShows.AddAsync(new TVShow
            {
                id = Guid.NewGuid(),
                name = "Severance",
                description = "Mark leads a team of office workers whose memories have been surgically divided between their work and personal lives. When a mysterious colleague appears outside of work, it begins a journey to discover the truth about their jobs.",
                episodes = 19,
                Genres = severanceGenres,
            });
            await dbContext.SaveChangesAsync();

            var walken = await dbContext.Actors.Where(x => x.name == "Christopher Walken").FirstOrDefaultAsync();
            var severance = await dbContext.TVShows.Where(x => x.name == "Severance").FirstOrDefaultAsync();

            var actorTvShow = new ActorTVShow
            {
                Actor = walken,
                TVShow = severance,
                Role = "Burt Goodman"
            };
            await dbContext.ActorsTVShows.AddAsync(actorTvShow);

            List<Genre> sevenPGenres = new List<Genre>();
            if (Comedy != null)
            {
                severanceGenres.Add(Comedy);
            }

            await dbContext.Movies.AddAsync(new Movie
            {
                id = Guid.NewGuid(),
                name = "Seven Psychopaths",
                description = "A struggling screenwriter inadvertently becomes entangled in the Los Angeles criminal underworld after his oddball friends kidnap a gangster's beloved Shih Tzu."
            ,
                Genres = sevenPGenres
            });
            await dbContext.SaveChangesAsync();

            var sevenP = await dbContext.Movies.Where(x => x.name == "Seven Psychopaths").FirstOrDefaultAsync();
            var actorMovie = new ActorMovie
            {
                Actor = walken,
                Movie = sevenP,
                Role = "Hans"
            };
            await dbContext.ActorsMovies.AddAsync(actorMovie);
            await dbContext.SaveChangesAsync();
        }
    }
}
