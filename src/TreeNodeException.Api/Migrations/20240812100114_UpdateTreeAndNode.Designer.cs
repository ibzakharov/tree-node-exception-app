﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TreeNodeException.Api.Models;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240812100114_UpdateTreeAndNode")]
    partial class UpdateTreeAndNode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Node", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("TreeId")
                        .HasColumnType("integer");

                    b.HasKey("NodeId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TreeId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("Tree", b =>
                {
                    b.Property<int>("TreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TreeId"));

                    b.Property<string>("TreeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TreeId");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("TreeNodeException.Api.Models.ExceptionLog", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventId"));

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExceptionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestQueryParams")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("EventId");

                    b.ToTable("ExceptionLogs");
                });

            modelBuilder.Entity("Node", b =>
                {
                    b.HasOne("Node", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tree", "Tree")
                        .WithMany("Nodes")
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Tree");
                });

            modelBuilder.Entity("Node", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Tree", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}
