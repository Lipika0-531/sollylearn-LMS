﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SollyLearn.API.Data;

#nullable disable

namespace SollyLearn.API.Migrations
{
    [DbContext(typeof(SollyLearnDbContext))]
    partial class SollyLearnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SollyLearn.API.Models.Domain.Image", b =>
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

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SollyLearn.API.Models.Domain.TechStack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechStackImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TechStacks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("505037a5-be9d-4b30-b1ab-6dcff18ae655"),
                            Description = "First Frontend Video",
                            Name = "FrontEnd",
                            TechStackImageURL = ""
                        },
                        new
                        {
                            Id = new Guid("7fc2efac-fe9f-4996-af23-b4f127bb7752"),
                            Description = "First C# Video",
                            Name = "C#",
                            TechStackImageURL = ""
                        },
                        new
                        {
                            Id = new Guid("a4eb5696-0e8e-417b-bf47-cdcca646e9bb"),
                            Description = "First LabView Video",
                            Name = "LabView",
                            TechStackImageURL = ""
                        },
                        new
                        {
                            Id = new Guid("e93cb985-4533-4df8-bf6b-0e4e4c18d320"),
                            Description = "First Python Video",
                            Name = "Python",
                            TechStackImageURL = ""
                        },
                        new
                        {
                            Id = new Guid("41b65a0e-1097-4759-a51c-e031d6ceb8b6"),
                            Description = "First Learning Video",
                            Name = "Utkarsh",
                            TechStackImageURL = ""
                        });
                });

            modelBuilder.Entity("SollyLearn.API.Models.Domain.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TechStackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TechStackId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8a86a48-51f9-4db4-bca5-99391c05d1de"),
                            DateTime = new DateTime(2024, 3, 26, 21, 50, 3, 537, DateTimeKind.Local).AddTicks(2001),
                            Description = "My First Video",
                            FilePath = "FilePath of the First video",
                            TechStackId = new Guid("7fc2efac-fe9f-4996-af23-b4f127bb7752"),
                            Title = "Title"
                        },
                        new
                        {
                            Id = new Guid("37be0b6d-e5c8-4cc0-8440-492dad53197e"),
                            DateTime = new DateTime(2024, 3, 26, 21, 50, 3, 537, DateTimeKind.Local).AddTicks(2030),
                            Description = "My Second Video",
                            FilePath = "FilePath of the Second video",
                            TechStackId = new Guid("505037a5-be9d-4b30-b1ab-6dcff18ae655"),
                            Title = "SecondTitle"
                        });
                });

            modelBuilder.Entity("SollyLearn.API.Models.Domain.Video", b =>
                {
                    b.HasOne("SollyLearn.API.Models.Domain.TechStack", "TechStack")
                        .WithMany()
                        .HasForeignKey("TechStackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TechStack");
                });
#pragma warning restore 612, 618
        }
    }
}
