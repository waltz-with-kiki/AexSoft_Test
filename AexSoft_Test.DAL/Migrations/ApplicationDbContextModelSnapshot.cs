﻿// <auto-generated />
using System;
using AexSoft_Test.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AexSoft_Test.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("AexSoft_Test.Domain.Models.Actor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.ActorMovie", b =>
                {
                    b.Property<Guid>("ActorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorsMovies");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.ActorTVShow", b =>
                {
                    b.Property<Guid>("ActorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TVShowId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ActorId", "TVShowId");

                    b.HasIndex("TVShowId");

                    b.ToTable("ActorsTVShows");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.Genre", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.Movie", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.TVShow", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<int>("episodes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("TVShows");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("Genresid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Moviesid")
                        .HasColumnType("TEXT");

                    b.HasKey("Genresid", "Moviesid");

                    b.HasIndex("Moviesid");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("GenreTVShow", b =>
                {
                    b.Property<Guid>("Genresid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TVShowsid")
                        .HasColumnType("TEXT");

                    b.HasKey("Genresid", "TVShowsid");

                    b.HasIndex("TVShowsid");

                    b.ToTable("GenreTVShow");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.ActorMovie", b =>
                {
                    b.HasOne("AexSoft_Test.Domain.Models.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AexSoft_Test.Domain.Models.Movie", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.ActorTVShow", b =>
                {
                    b.HasOne("AexSoft_Test.Domain.Models.Actor", "Actor")
                        .WithMany("TVShows")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AexSoft_Test.Domain.Models.TVShow", "TVShow")
                        .WithMany("Actors")
                        .HasForeignKey("TVShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("TVShow");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("AexSoft_Test.Domain.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("Genresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AexSoft_Test.Domain.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("Moviesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreTVShow", b =>
                {
                    b.HasOne("AexSoft_Test.Domain.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("Genresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AexSoft_Test.Domain.Models.TVShow", null)
                        .WithMany()
                        .HasForeignKey("TVShowsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.Actor", b =>
                {
                    b.Navigation("Movies");

                    b.Navigation("TVShows");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.Movie", b =>
                {
                    b.Navigation("Actors");
                });

            modelBuilder.Entity("AexSoft_Test.Domain.Models.TVShow", b =>
                {
                    b.Navigation("Actors");
                });
#pragma warning restore 612, 618
        }
    }
}
