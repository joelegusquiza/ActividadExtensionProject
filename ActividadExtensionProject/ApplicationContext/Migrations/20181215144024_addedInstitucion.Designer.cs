﻿// <auto-generated />
using System;
using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationContext.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181215144024_addedInstitucion")]
    partial class addedInstitucion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.ActaEU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("CarreraId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("EstudianteId");

                    b.Property<int>("UserCreatedId");

                    b.Property<int>("UserModifiedId");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("ActasEU");
                });

            modelBuilder.Entity("Core.Entities.ActaEUDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActaEUId");

                    b.Property<bool>("Active");

                    b.Property<int?>("CategoriaId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTimeOffset>("FechaFin");

                    b.Property<DateTimeOffset>("FechaInicio");

                    b.Property<int>("HorasExtensionRealizadas");

                    b.Property<int>("HorasRelojRealizadas");

                    b.Property<string>("Institucion");

                    b.Property<string>("LugarProfesorTutor");

                    b.Property<int?>("SubCategoriaId");

                    b.Property<int>("UserCreatedId");

                    b.Property<int>("UserModifiedId");

                    b.HasKey("Id");

                    b.HasIndex("ActaEUId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("SubCategoriaId");

                    b.ToTable("ActasEUDetalles");
                });

            modelBuilder.Entity("Core.Entities.Carrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Nombre");

                    b.Property<int>("UserCreatedId");

                    b.Property<int>("UserModifiedId");

                    b.HasKey("Id");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("Core.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Caracter");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Descripcion");

                    b.Property<int>("HoraExtension");

                    b.Property<int>("HoraReloj");

                    b.Property<string>("Nombre");

                    b.Property<int>("UserCreatedId");

                    b.Property<int>("UserModifiedId");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Core.Entities.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Apellido");

                    b.Property<int>("CarreraId");

                    b.Property<string>("CedulaIdentidad");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Nombre");

                    b.Property<int>("Sexo");

                    b.Property<int>("UserCreatedId");

                    b.Property<int>("UserModifiedId");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Core.Entities.SubCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Caracter");

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Nombre");

                    b.Property<int>("UserCreatedId");

                    b.Property<int>("UserModifiedId");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("SubCategorias");
                });

            modelBuilder.Entity("Core.Entities.ActaEU", b =>
                {
                    b.HasOne("Core.Entities.Carrera", "Carrera")
                        .WithMany("Actas")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Estudiante", "Estudiante")
                        .WithMany("Actas")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.ActaEUDetalle", b =>
                {
                    b.HasOne("Core.Entities.ActaEU", "Acta")
                        .WithMany("ActaEUDetalle")
                        .HasForeignKey("ActaEUId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Categoria", "Categoria")
                        .WithMany("ActaEUDetalle")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Core.Entities.SubCategoria", "SubCategoria")
                        .WithMany("ActaEUDetalle")
                        .HasForeignKey("SubCategoriaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.Estudiante", b =>
                {
                    b.HasOne("Core.Entities.Carrera", "Carrera")
                        .WithMany("Estudiantes")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.SubCategoria", b =>
                {
                    b.HasOne("Core.Entities.Categoria", "Categoria")
                        .WithMany("SubCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
