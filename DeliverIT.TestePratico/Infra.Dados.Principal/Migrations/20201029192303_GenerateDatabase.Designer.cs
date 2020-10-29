﻿// <auto-generated />
using System;
using Infra.Dados.Principal.DbContexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Dados.Principal.Migrations
{
    [DbContext(typeof(DbContextTeste))]
    [Migration("20201029192303_GenerateDatabase")]
    partial class GenerateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Principal.Entidades.ContasPagar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ContasPagar");
                });

            modelBuilder.Entity("Dominio.Principal.Entidades.ContasPagarBaixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContasPagarId")
                        .HasColumnType("int");

                    b.Property<decimal>("PercentualJurosDia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentualMulta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QtdeDiasAtraso")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContasPagarId");

                    b.ToTable("ContasPagarBaixas");
                });

            modelBuilder.Entity("Dominio.Principal.Entidades.ContasPagarBaixa", b =>
                {
                    b.HasOne("Dominio.Principal.Entidades.ContasPagar", "ContasPagar")
                        .WithMany("ContasPagarBaixa")
                        .HasForeignKey("ContasPagarId");
                });
#pragma warning restore 612, 618
        }
    }
}
