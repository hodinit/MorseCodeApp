﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MorseCodeApp2.Data;

#nullable disable

namespace MorseCodeApp2.Migrations
{
    [DbContext(typeof(MorseCodeApp2Context))]
    [Migration("20250116134230_mig4")]
    partial class mig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MorseCodeApp2.Models.CustomMask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomEquivalent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("CustomMask");
                });

            modelBuilder.Entity("MorseCodeApp2.Models.Date", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Date");
                });

            modelBuilder.Entity("MorseCodeApp2.Models.MorseDefaultConversion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("MorseEquivalent")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("ID");

                    b.ToTable("MorseDefaultConversion");
                });

            modelBuilder.Entity("MorseCodeApp2.Models.Sentence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomMaskID")
                        .HasColumnType("int");

                    b.Property<int?>("DateID")
                        .HasColumnType("int");

                    b.Property<string>("Input")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MorseDefaultConversionID")
                        .HasColumnType("int");

                    b.Property<string>("Output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomMaskID");

                    b.HasIndex("DateID");

                    b.HasIndex("MorseDefaultConversionID");

                    b.HasIndex("UserID");

                    b.ToTable("Sentence");
                });

            modelBuilder.Entity("MorseCodeApp2.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool?>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MorseCodeApp2.Models.CustomMask", b =>
                {
                    b.HasOne("MorseCodeApp2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MorseCodeApp2.Models.Sentence", b =>
                {
                    b.HasOne("MorseCodeApp2.Models.CustomMask", "CustomMask")
                        .WithMany()
                        .HasForeignKey("CustomMaskID");

                    b.HasOne("MorseCodeApp2.Models.Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateID");

                    b.HasOne("MorseCodeApp2.Models.MorseDefaultConversion", "MorseDefaultConversion")
                        .WithMany()
                        .HasForeignKey("MorseDefaultConversionID");

                    b.HasOne("MorseCodeApp2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("CustomMask");

                    b.Navigation("Date");

                    b.Navigation("MorseDefaultConversion");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
