﻿// <auto-generated />
using System;
using LearningEntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearningEntityFramework.Migrations
{
    [DbContext(typeof(LojaContext))]
    partial class LojaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LearningEntityFramework.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("LearningEntityFramework.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("float");

                    b.Property<string>("Unidade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LearningEntityFramework.Promocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promocaos");
                });

            modelBuilder.Entity("LearningEntityFramework.PromocaoProduto", b =>
                {
                    b.Property<int>("PromocaoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("PromocaoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PromocaoProduto");
                });

            modelBuilder.Entity("LearningEntityFramework.Compra", b =>
                {
                    b.HasOne("LearningEntityFramework.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LearningEntityFramework.PromocaoProduto", b =>
                {
                    b.HasOne("LearningEntityFramework.Produto", "Produto")
                        .WithMany("Prmocoes")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningEntityFramework.Promocao", "Promocao")
                        .WithMany("Produtos")
                        .HasForeignKey("PromocaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Promocao");
                });

            modelBuilder.Entity("LearningEntityFramework.Produto", b =>
                {
                    b.Navigation("Prmocoes");
                });

            modelBuilder.Entity("LearningEntityFramework.Promocao", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
