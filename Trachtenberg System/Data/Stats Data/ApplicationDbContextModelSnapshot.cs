﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trachtenberg_System.Data;

#nullable disable

namespace Trachtenberg_System.Data.StatsData
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trachtenberg_System.Models.HighScoresModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MultiplicationEasyTestScore")
                        .HasColumnType("int");

                    b.Property<int>("UserStatsModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserStatsModelId")
                        .IsUnique();

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

                    b.HasKey("Id");

                    b.ToTable("UserStats");
                });

            modelBuilder.Entity("Trachtenberg_System.Models.HighScoresModel", b =>
                {
                    b.HasOne("Trachtenberg_System.Models.UserStatsModel", "UserStatsModel")
                        .WithOne("HighScore")
                        .HasForeignKey("Trachtenberg_System.Models.HighScoresModel", "UserStatsModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStatsModel");
                });

            modelBuilder.Entity("Trachtenberg_System.Models.UserStatsModel", b =>
                {
                    b.Navigation("HighScore");
                });
#pragma warning restore 612, 618
        }
    }
}
