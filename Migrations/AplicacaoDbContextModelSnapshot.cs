﻿// <auto-generated />
using System;
using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EF.Exemplo6.Migrations
{
    [DbContext(typeof(AplicacaoDbContext))]
    partial class AplicacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EF.Exemplo6.Autor", b =>
                {
                    b.Property<int>("AutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AutorID"));

                    b.Property<DateOnly?>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("AutorID");

                    b.HasIndex("Nome");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("EF.Exemplo6.Endereco", b =>
                {
                    b.Property<int>("EnderecoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EnderecoID"));

                    b.Property<int>("AutorID")
                        .HasColumnType("integer");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.HasKey("EnderecoID");

                    b.HasIndex("AutorID")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("EF.Exemplo6.Genero", b =>
                {
                    b.Property<int>("GeneroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GeneroID"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("GeneroID");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("EF.Exemplo6.Livro", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<int>("AutorID")
                        .HasColumnType("integer");

                    b.Property<int?>("Paginas")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeEmEstoque")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.HasKey("ISBN");

                    b.HasIndex("AutorID");

                    b.HasIndex("Titulo");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("EF.Exemplo6.LivroGenero", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<int>("GeneroID")
                        .HasColumnType("integer");

                    b.HasKey("ISBN", "GeneroID");

                    b.HasIndex("GeneroID");

                    b.ToTable("LivroGenero");
                });

            modelBuilder.Entity("EF.Exemplo6.Endereco", b =>
                {
                    b.HasOne("EF.Exemplo6.Autor", "Autor")
                        .WithOne("Endereco")
                        .HasForeignKey("EF.Exemplo6.Endereco", "AutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("EF.Exemplo6.Livro", b =>
                {
                    b.HasOne("EF.Exemplo6.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("EF.Exemplo6.LivroGenero", b =>
                {
                    b.HasOne("EF.Exemplo6.Genero", "Genero")
                        .WithMany("Livros")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF.Exemplo6.Livro", "Livro")
                        .WithMany("Generos")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("EF.Exemplo6.Autor", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Livros");
                });

            modelBuilder.Entity("EF.Exemplo6.Genero", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("EF.Exemplo6.Livro", b =>
                {
                    b.Navigation("Generos");
                });
#pragma warning restore 612, 618
        }
    }
}
