﻿// <auto-generated />
using System;
using KolpackiRWypozyczalnia.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KolpackiRWypozyczalnia.Migrations
{
    [DbContext(typeof(FilmContext))]
    [Migration("20230322124542_Publishdata")]
    partial class Publishdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KolpackiRWypozyczalnia.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Straszne filmy",
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Filmy oparte na faktach",
                            Name = "Dokumentalne"
                        },
                        new
                        {
                            Id = 3,
                            Desc = "Dreszczowce",
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 4,
                            Desc = "Filmy z akcją",
                            Name = "Sensacyjne"
                        },
                        new
                        {
                            Id = 5,
                            Desc = "Elementy magiiczne i nadprzyrodzone",
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("KolpackiRWypozyczalnia.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Desc = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                            Director = "Marcus Nispel",
                            Price = 10m,
                            PublishDate = new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Teksańska Masakra Piłą Mechaniczną"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Desc = "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.",
                            Director = "Joel Schumacher",
                            Price = 14m,
                            PublishDate = new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Numer 23"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Desc = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                            Director = "David Koepp",
                            Price = 12m,
                            PublishDate = new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Sekretne Okno"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 5,
                            Desc = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                            Director = "Peter Jackson",
                            Price = 20m,
                            PublishDate = new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Władca Pierścieni: Drużyna Pierścienia"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Desc = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                            Director = "Robert Schwentke",
                            Price = 11m,
                            PublishDate = new DateTime(2020, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Red"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Desc = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                            Director = "Tomasz Sekielski",
                            Price = 0m,
                            PublishDate = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Tylko nie mów nikomu"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 5,
                            Desc = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                            Director = "Neil Burger",
                            Price = 13m,
                            PublishDate = new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Iluzjonista"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Desc = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                            Director = "Vincenzo Natali",
                            Price = 15m,
                            PublishDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Cube"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Desc = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                            Director = "Clive Barker",
                            Price = 16m,
                            PublishDate = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hellraiser: Wysłannik Piekieł"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Desc = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                            Director = "Jonathan Demme",
                            Price = 17m,
                            PublishDate = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Milczenie Owiec"
                        });
                });

            modelBuilder.Entity("KolpackiRWypozyczalnia.Models.Film", b =>
                {
                    b.HasOne("KolpackiRWypozyczalnia.Models.Category", "Category")
                        .WithMany("Films")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KolpackiRWypozyczalnia.Models.Category", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
