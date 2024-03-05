﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trachtenberg_System.Data;

#nullable disable

namespace Trachtenberg_System.Data.StatsData
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240304200031_even more advanced")]
    partial class evenmoreadvanced
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trachtenberg_System.Models.HighScoresClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MultiplicationEasyTestScore")
                        .HasColumnType("int");

                    b.Property<int>("UserStatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HighScores");
                });

            modelBuilder.Entity("Trachtenberg_System.Models.UserStatsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HighScoresId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserStats");
                });
#pragma warning restore 612, 618
        }
    }
}
