﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieRate.Infra.Data;

#nullable disable

namespace MovieRate.Infra.Migrations;

[DbContext(typeof(MovieRateDbContext))]
partial class MovieRateDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "9.0.4")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("MovieRate.Domain.Entities.MovieRating", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Comment")
                    .HasMaxLength(1000)
                    .HasColumnType("nvarchar(1000)");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("datetime2");

                b.Property<int>("MovieId")
                    .HasColumnType("int");

                b.Property<int>("Rating")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("MovieRatings", (string)null);
            });
#pragma warning restore 612, 618
    }
}
