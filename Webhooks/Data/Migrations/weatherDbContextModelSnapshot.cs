﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webhooks.Data;

#nullable disable

namespace Webhooks.Data.Migrations
{
    [DbContext(typeof(weatherDbContext))]
    partial class weatherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Webhooks.Models.WeatherData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Humidity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Temperature")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Weathers");
                });
#pragma warning restore 612, 618
        }
    }
}
