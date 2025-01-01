﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCRUD.API.Data;

#nullable disable

namespace WebApiCRUD.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250101185459_Seeding data for Difficultie and Region")]
    partial class SeedingdataforDifficultieandRegion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiCRUD.API.Domain.Entity.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a4f0398-b3d9-4ea2-83ae-f559ac721e31"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("d342f55b-fe02-4319-a6db-ac8f89869db2"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("bbfc77d5-ba2f-4080-a34d-1363189af83a"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("WebApiCRUD.API.Domain.Entity.FileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("FileEntities");
                });

            modelBuilder.Entity("WebApiCRUD.API.Domain.Entity.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("09085de6-8908-42b7-81f5-d439738a60ab"),
                            Code = "BOP",
                            Name = "Bay of plenty"
                        },
                        new
                        {
                            Id = new Guid("c3acc73e-a87d-4c47-afb6-ad9c304f13a9"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "https://www.google.com/imgres?q=image&imgurl=https%3A%2F%2Fcdn.prod.website-files.com%2F62d84e447b4f9e7263d31e94%2F6399a4d27711a5ad2c9bf5cd_ben-sweet-2LowviVHZ-E-unsplash-1.jpeg&imgrefurl=https%3A%2F%2Fwww.pixsy.com%2Fimage-theft%2Fverify-image-source-copyright-owner&docid=XUAyne4_INagNM&tbnid=HXLlNEpHoJATkM&vet=12ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGEQAA..i&w=1920&h=1080&hcb=2&ved=2ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGEQAA"
                        },
                        new
                        {
                            Id = new Guid("453b3e72-7991-4a4f-a3c4-0803f53da7b0"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "https://www.google.com/imgres?q=image&imgurl=https%3A%2F%2Fcreate.microsoft.com%2F_next%2Fimage%3Furl%3Dhttps%253A%252F%252Fdsgrcdnblobprod5u3.azureedge.net%252Fimages%252Fimage-creator-B03_mapletree.webp%26w%3D1920%26q%3D90&imgrefurl=https%3A%2F%2Fcreate.microsoft.com%2Fen-us%2Ffeatures%2Fai-image-generator&docid=5UlSeOv_qEH1jM&tbnid=fTlcbXO2uO_rDM&vet=12ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGAQAA..i&w=1024&h=1024&hcb=2&itg=1&ved=2ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGAQAA"
                        });
                });

            modelBuilder.Entity("WebApiCRUD.API.Domain.Entity.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalksImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("WebApiCRUD.API.Domain.Entity.Walk", b =>
                {
                    b.HasOne("WebApiCRUD.API.Domain.Entity.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCRUD.API.Domain.Entity.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}