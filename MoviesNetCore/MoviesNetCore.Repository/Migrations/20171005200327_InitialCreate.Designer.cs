﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MoviesNetCore.Repository;
using System;

namespace MoviesNetCore.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20171005200327_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MoviesNetCore.Model.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MoviesNetCore.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverLink");

                    b.Property<string>("Name");

                    b.Property<string>("Plot");

                    b.Property<DateTime?>("ReleaseDate");

                    b.Property<int?>("Runtime");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesNetCore.Model.MovieGenre", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("GenreId");

                    b.Property<Guid?>("GenreId1");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId1");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("MoviesNetCore.Model.MovieGenre", b =>
                {
                    b.HasOne("MoviesNetCore.Model.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId1");

                    b.HasOne("MoviesNetCore.Model.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
