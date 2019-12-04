﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Domain.GameSettings", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardHeight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BoardString")
                        .HasColumnType("TEXT");

                    b.Property<int>("BoardWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstPlayerName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPlayerOne")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumTurns")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SaveName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SaveTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondPlayerName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("VersusBot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("YCoordinateString")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
