﻿// <auto-generated />
using System;
using ChoreDataModel.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chores.Migrations
{
    [DbContext(typeof(ChoreContext))]
    [Migration("20200524124419_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChoreDataModel.Model.Chore", b =>
                {
                    b.Property<int>("ChoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Assigned")
                        .HasColumnType("bit");

                    b.Property<int?>("AssignedPartnerId")
                        .HasColumnType("int");

                    b.Property<string>("ChoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Completed")
                        .HasColumnType("bit");

                    b.HasKey("ChoreID");

                    b.ToTable("Chore");
                });
#pragma warning restore 612, 618
        }
    }
}
