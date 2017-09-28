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
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

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

                    b.ToTable("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}