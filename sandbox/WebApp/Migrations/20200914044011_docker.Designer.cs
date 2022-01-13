﻿// <auto-generated />
using DFrame.Profiler.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApp.Migrations
{
    [DbContext(typeof(DFrameProfilerContext))]
    [Migration("20200914044011_docker")]
    partial class docker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DFrame.Profiler.Context.ProfileHistory", b =>
                {
                    b.Property<string>("HistoryId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Argument")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ContextId")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Duration")
                        .HasColumnType("double");

                    b.Property<int>("Errors")
                        .HasColumnType("int");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Requests")
                        .HasColumnType("int");

                    b.Property<string>("WorkloadName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("HistoryId");

                    b.ToTable("ProfileHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
