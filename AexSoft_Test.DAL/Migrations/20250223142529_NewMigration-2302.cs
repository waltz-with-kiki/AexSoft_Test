using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AexSoft_Test.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2302 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    episodes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ActorsMovies",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MovieId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsMovies", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    Genresid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Moviesid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.Genresid, x.Moviesid });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_Genresid",
                        column: x => x.Genresid,
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_Moviesid",
                        column: x => x.Moviesid,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorsTVShows",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TVShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsTVShows", x => new { x.ActorId, x.TVShowId });
                    table.ForeignKey(
                        name: "FK_ActorsTVShows_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsTVShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreTVShow",
                columns: table => new
                {
                    Genresid = table.Column<Guid>(type: "TEXT", nullable: false),
                    TVShowsid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTVShow", x => new { x.Genresid, x.TVShowsid });
                    table.ForeignKey(
                        name: "FK_GenreTVShow_Genres_Genresid",
                        column: x => x.Genresid,
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTVShow_TVShows_TVShowsid",
                        column: x => x.TVShowsid,
                        principalTable: "TVShows",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorsMovies_MovieId",
                table: "ActorsMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsTVShows_TVShowId",
                table: "ActorsTVShows",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_Moviesid",
                table: "GenreMovie",
                column: "Moviesid");

            migrationBuilder.CreateIndex(
                name: "IX_GenreTVShow_TVShowsid",
                table: "GenreTVShow",
                column: "TVShowsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsMovies");

            migrationBuilder.DropTable(
                name: "ActorsTVShows");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "GenreTVShow");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "TVShows");
        }
    }
}
