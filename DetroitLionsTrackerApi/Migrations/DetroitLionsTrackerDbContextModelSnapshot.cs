﻿// <auto-generated />
using System;
using DetroitLionsTrackerApi.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DetroitLionsTrackerApi.Migrations
{
    [DbContext(typeof(DetroitLionsTrackerDbContext))]
    partial class DetroitLionsTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.DefensiveGameStats", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<int>("ForcedFumbles")
                        .HasColumnType("int");

                    b.Property<int>("FumblesRecovered")
                        .HasColumnType("int");

                    b.Property<int>("IntYards")
                        .HasColumnType("int");

                    b.Property<int>("Interceptions")
                        .HasColumnType("int");

                    b.Property<int>("PassesDeflected")
                        .HasColumnType("int");

                    b.Property<int>("Sacks")
                        .HasColumnType("int");

                    b.Property<int>("Safeties")
                        .HasColumnType("int");

                    b.Property<int>("Tackles")
                        .HasColumnType("int");

                    b.Property<int>("TacklesForLoss")
                        .HasColumnType("int");

                    b.Property<int>("Touchdowns")
                        .HasColumnType("int");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("DefensiveGameStats", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Game", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Opponent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("SeasonId")
                        .HasColumnType("bigint");

                    b.HasKey("GameId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.OffensiveGameStats", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<int>("Drops")
                        .HasColumnType("int");

                    b.Property<int>("Fumbles")
                        .HasColumnType("int");

                    b.Property<int>("Interceptions")
                        .HasColumnType("int");

                    b.Property<int>("PassingAttempts")
                        .HasColumnType("int");

                    b.Property<int>("PassingCompletions")
                        .HasColumnType("int");

                    b.Property<int>("PassingTouchdowns")
                        .HasColumnType("int");

                    b.Property<int>("PassingYards")
                        .HasColumnType("int");

                    b.Property<int>("ReceivingTouchdowns")
                        .HasColumnType("int");

                    b.Property<int>("ReceivingYards")
                        .HasColumnType("int");

                    b.Property<int>("Receptions")
                        .HasColumnType("int");

                    b.Property<int>("RushingAttempts")
                        .HasColumnType("int");

                    b.Property<int>("RushingTouchdowns")
                        .HasColumnType("int");

                    b.Property<int>("RushingYards")
                        .HasColumnType("int");

                    b.Property<int>("Targets")
                        .HasColumnType("int");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("OffensiveGameStats", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Player", b =>
                {
                    b.Property<long>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("DepthChartOrder")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsOnRoster")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PlayerId");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Season", b =>
                {
                    b.Property<long>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Record")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SeasonId");

                    b.ToTable("Season", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.SeasonPlayers", b =>
                {
                    b.Property<long>("SeasonPlayersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<long>("SeasonId")
                        .HasColumnType("bigint");

                    b.HasKey("SeasonPlayersId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.ToTable("SeasonPlayers", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.SpecialTeamsGameStats", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<int>("FGAttempts")
                        .HasColumnType("int");

                    b.Property<int>("FGMade")
                        .HasColumnType("int");

                    b.Property<int>("KickReturnYards")
                        .HasColumnType("int");

                    b.Property<int>("KickReturns")
                        .HasColumnType("int");

                    b.Property<int>("PuntReturnYards")
                        .HasColumnType("int");

                    b.Property<int>("PuntReturns")
                        .HasColumnType("int");

                    b.Property<int>("PuntYards")
                        .HasColumnType("int");

                    b.Property<int>("Punts")
                        .HasColumnType("int");

                    b.Property<int>("Touchdowns")
                        .HasColumnType("int");

                    b.Property<int>("XPAttempts")
                        .HasColumnType("int");

                    b.Property<int>("XPMade")
                        .HasColumnType("int");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("SpecialTeamsGameStats", (string)null);
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.DefensiveGameStats", b =>
                {
                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Game", "Game")
                        .WithMany("DefensiveGameStats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Player", "Player")
                        .WithMany("DefensiveGameStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Game", b =>
                {
                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Season", "Season")
                        .WithMany("Games")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.OffensiveGameStats", b =>
                {
                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Game", "Game")
                        .WithMany("OffensiveGameStats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Player", "Player")
                        .WithMany("OffensiveGameStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.SeasonPlayers", b =>
                {
                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Player", "Player")
                        .WithMany("SeasonPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Season", "Season")
                        .WithMany("SeasonPlayers")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.SpecialTeamsGameStats", b =>
                {
                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Game", "Game")
                        .WithMany("SpecialTeamsGameStats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DetroitLionsTrackerApi.Models.Entity.Player", "Player")
                        .WithMany("SpecialTeamsGameStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Game", b =>
                {
                    b.Navigation("DefensiveGameStats");

                    b.Navigation("OffensiveGameStats");

                    b.Navigation("SpecialTeamsGameStats");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Player", b =>
                {
                    b.Navigation("DefensiveGameStats");

                    b.Navigation("OffensiveGameStats");

                    b.Navigation("SeasonPlayers");

                    b.Navigation("SpecialTeamsGameStats");
                });

            modelBuilder.Entity("DetroitLionsTrackerApi.Models.Entity.Season", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("SeasonPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
