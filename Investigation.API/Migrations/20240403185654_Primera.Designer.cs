﻿// <auto-generated />
using System;
using Investigation.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Investigation.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240403185654_Primera")]
    partial class Primera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Investigation.Shared.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProyectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectsId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.ActivityResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivitiesId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<int>("ResourcesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivitiesId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("ActivityResources");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Investigator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Afiliacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Investigators");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.InvestigatorProyect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InvestigatorId")
                        .HasColumnType("int");

                    b.Property<int>("ProyectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvestigatorId");

                    b.HasIndex("ProyectId");

                    b.ToTable("InvestigatorProyects");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Proyect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Proyects");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaPrublicacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProyectsId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProyectsId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadRequerida")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEntregaEstimada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Proveedor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProyectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectsId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Activity", b =>
                {
                    b.HasOne("Investigation.Shared.Entities.Proyect", "Proyects")
                        .WithMany("Activities")
                        .HasForeignKey("ProyectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.ActivityResource", b =>
                {
                    b.HasOne("Investigation.Shared.Entities.Activity", "Activities")
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Investigation.Shared.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Investigation.Shared.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Investigation.Shared.Entities.Resource", "Resources")
                        .WithMany()
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activities");

                    b.Navigation("Activity");

                    b.Navigation("Resource");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.InvestigatorProyect", b =>
                {
                    b.HasOne("Investigation.Shared.Entities.Investigator", "Investigators")
                        .WithMany()
                        .HasForeignKey("InvestigatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Investigation.Shared.Entities.Proyect", "Proyects")
                        .WithMany()
                        .HasForeignKey("ProyectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investigators");

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Publication", b =>
                {
                    b.HasOne("Investigation.Shared.Entities.Proyect", "Proyects")
                        .WithMany("Publications")
                        .HasForeignKey("ProyectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Resource", b =>
                {
                    b.HasOne("Investigation.Shared.Entities.Proyect", "Proyects")
                        .WithMany("Resources")
                        .HasForeignKey("ProyectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("Investigation.Shared.Entities.Proyect", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Publications");

                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
