﻿// <auto-generated />
using CIT365_W9_MegaDeskV2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIT365_W9_MegaDeskV2.Migrations
{
    [DbContext(typeof(CIT365_W9_MegaDeskV2Context))]
    [Migration("20200226041642_Added relationships")]
    partial class Addedrelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIT365_W9_MegaDeskV2.Models.Desk", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("depth")
                        .HasColumnType("float");

                    b.Property<int>("drawers")
                        .HasColumnType("int");

                    b.Property<int>("surfaceMaterialid")
                        .HasColumnType("int");

                    b.Property<double>("width")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("surfaceMaterialid");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("CIT365_W9_MegaDeskV2.Models.DeskQuote", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("customerName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("deskid")
                        .HasColumnType("int");

                    b.Property<int>("rushTypeid")
                        .HasColumnType("int");

                    b.Property<double>("totalQuote")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("deskid");

                    b.HasIndex("rushTypeid");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("CIT365_W9_MegaDeskV2.Models.RushType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("tier1Cost")
                        .HasColumnType("real");

                    b.Property<float>("tier2Cost")
                        .HasColumnType("real");

                    b.Property<float>("tier3Cost")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("RushType");
                });

            modelBuilder.Entity("CIT365_W9_MegaDeskV2.Models.SurfaceMaterial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("cost")
                        .HasColumnType("real");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("imageFile")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("SurfaceMaterial");
                });

            modelBuilder.Entity("CIT365_W9_MegaDeskV2.Models.Desk", b =>
                {
                    b.HasOne("CIT365_W9_MegaDeskV2.Models.SurfaceMaterial", "surfaceMaterial")
                        .WithMany()
                        .HasForeignKey("surfaceMaterialid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CIT365_W9_MegaDeskV2.Models.DeskQuote", b =>
                {
                    b.HasOne("CIT365_W9_MegaDeskV2.Models.Desk", "desk")
                        .WithMany()
                        .HasForeignKey("deskid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CIT365_W9_MegaDeskV2.Models.RushType", "rushType")
                        .WithMany()
                        .HasForeignKey("rushTypeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
