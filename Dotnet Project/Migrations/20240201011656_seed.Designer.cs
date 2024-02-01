﻿// <auto-generated />
using System;
using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotnetProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240201011656_seed")]
    partial class seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dotnet_Project.Models.Lobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFull")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int?>("LinkedLobbyId")
                        .HasColumnType("int");

                    b.Property<int?>("LobbyId")
                        .HasColumnType("int");

                    b.Property<int?>("LobbyId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamNumber")
                        .HasColumnType("int");

                    b.Property<string>("mdp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number_draws")
                        .HasColumnType("int");

                    b.Property<int>("number_losses")
                        .HasColumnType("int");

                    b.Property<int>("number_wins")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LinkedLobbyId");

                    b.HasIndex("LobbyId");

                    b.HasIndex("LobbyId1");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EMail = "player1@example.com",
                            IsAdmin = false,
                            Name = "Ala",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password1",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 2,
                            EMail = "player2@example.com",
                            IsAdmin = false,
                            Name = "Taher",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password2",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 3,
                            EMail = "player3@example.com",
                            IsAdmin = false,
                            Name = "Habib",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password3",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 4,
                            EMail = "player4@example.com",
                            IsAdmin = false,
                            Name = "Fedy",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password4",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 5,
                            EMail = "player5@example.com",
                            IsAdmin = false,
                            Name = "Najar",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password5",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 6,
                            EMail = "player6@example.com",
                            IsAdmin = false,
                            Name = "Reb3i",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password6",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 7,
                            EMail = "player7@example.com",
                            IsAdmin = false,
                            Name = "Ghazi",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password7",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 8,
                            EMail = "player8@example.com",
                            IsAdmin = false,
                            Name = "Kamel",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password8",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 9,
                            EMail = "player9@example.com",
                            IsAdmin = false,
                            Name = "Karim",
                            PhotoPath = "path2",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password9",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 10,
                            EMail = "play10@example.com",
                            IsAdmin = false,
                            Name = "Samir",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password10",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 11,
                            EMail = "play11@example.com",
                            IsAdmin = false,
                            Name = "Kais",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password11",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 12,
                            EMail = "play12@example.com",
                            IsAdmin = false,
                            Name = "Aziz",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password12",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 13,
                            EMail = "play13@example.com",
                            IsAdmin = false,
                            Name = "Youssef",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password13",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 14,
                            EMail = "play14@example.com",
                            IsAdmin = false,
                            Name = "Hamza",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password14",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 15,
                            EMail = "play15@example.com",
                            IsAdmin = false,
                            Name = "Ali",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password15",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 16,
                            EMail = "play16@example.com",
                            IsAdmin = false,
                            Name = "Mustafa",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password16",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 17,
                            EMail = "play17@example.com",
                            IsAdmin = false,
                            Name = "Elyess",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password17",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 18,
                            EMail = "play18@example.com",
                            IsAdmin = false,
                            Name = "Omar",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password18",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 19,
                            EMail = "play19@example.com",
                            IsAdmin = false,
                            Name = "Ismail",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password19",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 20,
                            EMail = "play20@example.com",
                            IsAdmin = false,
                            Name = "Amine",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password20",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 21,
                            EMail = "play21@example.com",
                            IsAdmin = false,
                            Name = "Talel",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "passwor21",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 22,
                            EMail = "play22@example.com",
                            IsAdmin = false,
                            Name = "Yahya",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password22",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 23,
                            EMail = "play23@example.com",
                            IsAdmin = false,
                            Name = "Skander",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password23",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 24,
                            EMail = "play24@example.com",
                            IsAdmin = false,
                            Name = "Omar",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password24",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 25,
                            EMail = "play25@example.com",
                            IsAdmin = false,
                            Name = "Zahran",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password25",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 26,
                            EMail = "play26@example.com",
                            IsAdmin = false,
                            Name = "Mohamed",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password26",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 27,
                            EMail = "play27@example.com",
                            IsAdmin = false,
                            Name = "Fethi",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password27",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 28,
                            EMail = "play28@example.com",
                            IsAdmin = false,
                            Name = "Adem",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password28",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 29,
                            EMail = "play29@example.com",
                            IsAdmin = false,
                            Name = "Ahmed",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password29",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 30,
                            EMail = "play30@example.com",
                            IsAdmin = false,
                            Name = "Ayhem",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password30",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 31,
                            EMail = "play31@example.com",
                            IsAdmin = false,
                            Name = "Abderrahmen",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password31",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 32,
                            EMail = "play32@example.com",
                            IsAdmin = false,
                            Name = "Hamdi",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password32",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 33,
                            EMail = "play33@example.com",
                            IsAdmin = false,
                            Name = "Majd",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password33",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 34,
                            EMail = "play34@example.com",
                            IsAdmin = false,
                            Name = "Bachar",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password34",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        },
                        new
                        {
                            ID = 35,
                            EMail = "play35@example.com",
                            IsAdmin = false,
                            Name = "Oussama",
                            PhotoPath = "path1",
                            Surname = "Doe",
                            TeamNumber = 0,
                            mdp = "password35",
                            numberdraws = 0,
                            numberlosses = 0,
                            numberwins = 0
                        });
                });

            modelBuilder.Entity("Dotnet_Project.Models.Stade_Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StadeId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mdp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("StadeId");

                    b.ToTable("StadeOwners");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EMail = "owner1@example.com",
                            Name = "Owner1",
                            Surname = "Owner1Surname",
                            mdp = "password1"
                        },
                        new
                        {
                            ID = 2,
                            EMail = "owner2@example.com",
                            Name = "Owner2",
                            Surname = "Owner2Surname",
                            mdp = "password2"
                        });
                });

            modelBuilder.Entity("Dotnet_Project.Models.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exactLocalisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "CHOUF 3CHIRI A9WA STADE F TUNIS KAMLA W YOUFA LA7DITH",
                            Localisation = "Monastir",
                            Name = "May Land",
                            PhotoPath = "Images/StadeMay.png",
                            PhotoPath2 = "Images/StadeMay2.png",
                            exactLocalisation = "https://maps.app.goo.gl/qfwmuN7oYvZAHxgo6"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A9WA STADE FEL 3ASSMA",
                            Localisation = "Route De Sidi Younes El Borj",
                            Name = "Five Stars",
                            PhotoPath = "Images/StadeFive.png",
                            PhotoPath2 = "/Images/StadeFive2.png",
                            exactLocalisation = "https://maps.app.goo.gl/JuCkdWuti8xPFwsE9"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A5YEB STADE F TUNIS KAMLA",
                            Localisation = "Charguia",
                            Name = "Stade Charguia",
                            PhotoPath = "Images/StadeCharguia.png",
                            PhotoPath2 = "Images/StadeCharguia2.png",
                            exactLocalisation = "https://maps.app.goo.gl/SYJ6qQaWXY9MkE7XA"
                        },
                        new
                        {
                            Id = 4,
                            Description = "AWEL STADE F MAHDIA",
                            Localisation = "Mahdia",
                            Name = "MStadium",
                            PhotoPath = "Images/MStadium.png",
                            PhotoPath2 = "Images/MStadium2.png",
                            exactLocalisation = "https://maps.app.goo.gl/k5BGdbc26YHUTnsy6"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A7SSEN STADE F MAHDIA",
                            Localisation = "Rejiche",
                            Name = "Parc Des Princes",
                            PhotoPath = "Images/PDP.png",
                            PhotoPath2 = "Images/PDP2.png",
                            exactLocalisation = "https://maps.app.goo.gl/YqEoZrBDytUnh2Te9"
                        },
                        new
                        {
                            Id = 6,
                            Description = "STADE F WOST 7OMMA T5AWEF ",
                            Localisation = "Monastir",
                            Name = "Al Kahna",
                            PhotoPath = "Images/Kahna.png",
                            PhotoPath2 = "Images/Kahna2.png",
                            exactLocalisation = "https://maps.app.goo.gl/pHnjSerugXFYSRE39"
                        },
                        new
                        {
                            Id = 7,
                            Description = "EKTICHAF JDID",
                            Localisation = "Monastir",
                            Name = "Stade Sahara Beach",
                            PhotoPath = "Images/Sahara.png",
                            PhotoPath2 = "Images/Sahara2.png",
                            exactLocalisation = "https://maps.app.goo.gl/UGkynYQKBK7Mai9U6"
                        });
                });

            modelBuilder.Entity("Dotnet_Project.Models.Time_Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("end_time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("occupancy")
                        .HasColumnType("bit");

                    b.Property<DateTime>("start_time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StadiumId = 1,
                            endtime = new DateTime(2024, 2, 1, 3, 46, 56, 70, DateTimeKind.Local).AddTicks(1281),
                            occupancy = true,
                            starttime = new DateTime(2024, 2, 1, 2, 16, 56, 70, DateTimeKind.Local).AddTicks(1220)
                        },
                        new
                        {
                            Id = 2,
                            StadiumId = 2,
                            endtime = new DateTime(2024, 2, 1, 3, 46, 56, 70, DateTimeKind.Local).AddTicks(1290),
                            occupancy = false,
                            starttime = new DateTime(2024, 2, 1, 2, 16, 56, 70, DateTimeKind.Local).AddTicks(1289)
                        },
                        new
                        {
                            Id = 3,
                            StadiumId = 3,
                            endtime = new DateTime(2024, 2, 1, 3, 46, 56, 70, DateTimeKind.Local).AddTicks(1295),
                            occupancy = false,
                            starttime = new DateTime(2024, 2, 1, 2, 16, 56, 70, DateTimeKind.Local).AddTicks(1293)
                        },
                        new
                        {
                            Id = 4,
                            StadiumId = 1,
                            endtime = new DateTime(2024, 2, 1, 5, 46, 56, 70, DateTimeKind.Local).AddTicks(1299),
                            occupancy = false,
                            starttime = new DateTime(2024, 2, 1, 4, 16, 56, 70, DateTimeKind.Local).AddTicks(1298)
                        },
                        new
                        {
                            Id = 5,
                            StadiumId = 2,
                            endtime = new DateTime(2024, 2, 1, 5, 46, 56, 70, DateTimeKind.Local).AddTicks(1304),
                            occupancy = false,
                            starttime = new DateTime(2024, 2, 1, 4, 16, 56, 70, DateTimeKind.Local).AddTicks(1302)
                        },
                        new
                        {
                            Id = 6,
                            StadiumId = 3,
                            endtime = new DateTime(2024, 2, 1, 5, 46, 56, 70, DateTimeKind.Local).AddTicks(1308),
                            occupancy = false,
                            starttime = new DateTime(2024, 2, 1, 4, 16, 56, 70, DateTimeKind.Local).AddTicks(1307)
                        });
                });

            modelBuilder.Entity("Dotnet_Project.Models.Lobby", b =>
                {
                    b.HasOne("Dotnet_Project.Models.Time_Slot", "TimeSlot")
                        .WithMany("LinkedLobbies")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Player", b =>
                {
                    b.HasOne("Dotnet_Project.Models.Lobby", "LinkedLobby")
                        .WithMany("Players")
                        .HasForeignKey("LinkedLobbyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dotnet_Project.Models.Lobby", null)
                        .WithMany("Team1")
                        .HasForeignKey("LobbyId");

                    b.HasOne("Dotnet_Project.Models.Lobby", null)
                        .WithMany("Team2")
                        .HasForeignKey("LobbyId1");

                    b.Navigation("LinkedLobby");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Stade_Owner", b =>
                {
                    b.HasOne("Dotnet_Project.Models.Stadium", "stade")
                        .WithMany()
                        .HasForeignKey("StadeId");

                    b.Navigation("stade");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Time_Slot", b =>
                {
                    b.HasOne("Dotnet_Project.Models.Stadium", "stadium")
                        .WithMany("Times")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("stadium");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Lobby", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Stadium", b =>
                {
                    b.Navigation("Times");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Time_Slot", b =>
                {
                    b.Navigation("LinkedLobbies");
                });
#pragma warning restore 612, 618
        }
    }
}
