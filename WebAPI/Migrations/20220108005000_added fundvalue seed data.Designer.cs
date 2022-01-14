﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Model;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220108005000_added fundvalue seed data")]
    partial class addedfundvalueseeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("test5.Model.Fund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fund");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            description = "testDescription1",
                            name = "testName1"
                        },
                        new
                        {
                            Id = 2,
                            description = "testDescription2",
                            name = "testName2"
                        });
                });

            modelBuilder.Entity("test5.Model.FundValues", b =>
                {
                    b.Property<int>("fund_id")
                        .HasColumnType("int");

                    b.Property<decimal>("value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("value_date")
                        .HasColumnType("datetime2");

                    b.HasKey("fund_id");

                    b.ToTable("FundValues");

                    b.HasData(
                        new
                        {
                            fund_id = 1,
                            value = 630m,
                            value_date = new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("test5.Model.FundValues", b =>
                {
                    b.HasOne("test5.Model.Fund", "Fund")
                        .WithMany("FundValues")
                        .HasForeignKey("fund_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fund");
                });

            modelBuilder.Entity("test5.Model.Fund", b =>
                {
                    b.Navigation("FundValues");
                });
#pragma warning restore 612, 618
        }
    }
}