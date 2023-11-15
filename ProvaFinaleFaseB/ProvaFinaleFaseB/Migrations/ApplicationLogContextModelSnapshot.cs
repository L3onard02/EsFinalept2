﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProvaFinaleFaseB.DataSource;

#nullable disable

namespace ProvaFinaleFaseB.Migrations
{
    [DbContext(typeof(ApplicationLogContext))]
    partial class ApplicationLogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProvaFinaleFaseB.Entities.LogsEntity", b =>
                {
                    b.Property<int>("idLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idLog"));

                    b.Property<string>("EndpointUrl")
                        .HasColumnType("text");

                    b.Property<string>("Messaggio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("idLog");

                    b.ToTable("Utenti");
                });
#pragma warning restore 612, 618
        }
    }
}
