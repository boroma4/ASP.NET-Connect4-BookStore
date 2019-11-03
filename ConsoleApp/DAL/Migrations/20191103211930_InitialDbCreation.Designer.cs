﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191103211930_InitialDbCreation")]
    partial class InitialDbCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("GameEngine.GameSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstPlayerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GameBoard")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPlayerOne")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumTurns")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SaveName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaveTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondPlayerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ycoord")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
