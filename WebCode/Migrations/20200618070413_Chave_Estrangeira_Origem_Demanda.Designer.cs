﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCode.Models;

namespace WebCode.Migrations
{
    [DbContext(typeof(WebCodeContext))]
    [Migration("20200618070413_Chave_Estrangeira_Origem_Demanda")]
    partial class Chave_Estrangeira_Origem_Demanda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebCode.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acao");

                    b.Property<DateTime>("DataFinal");

                    b.Property<DateTime>("DataInicial");

                    b.Property<int?>("DemandaId");

                    b.Property<string>("NumeroProa");

                    b.Property<int>("Prazo");

                    b.Property<string>("Responsavel");

                    b.Property<string>("Setor");

                    b.Property<int>("Status");

                    b.Property<string>("TipoPrazo");

                    b.HasKey("Id");

                    b.HasIndex("DemandaId");

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("WebCode.Models.Demanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("DataFinal");

                    b.Property<DateTime>("DataInicial");

                    b.Property<string>("Descricao");

                    b.Property<string>("Numero");

                    b.Property<string>("NumeroProa");

                    b.Property<int>("OrigemId");

                    b.Property<int>("Prazo");

                    b.Property<string>("ProcessoOrigem");

                    b.Property<int>("Status");

                    b.Property<int>("TipoDemanda");

                    b.HasKey("Id");

                    b.HasIndex("OrigemId");

                    b.ToTable("Demanda");
                });

            modelBuilder.Entity("WebCode.Models.Origem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Origem");
                });

            modelBuilder.Entity("WebCode.Models.Atividade", b =>
                {
                    b.HasOne("WebCode.Models.Demanda", "Demanda")
                        .WithMany("Atividades")
                        .HasForeignKey("DemandaId");
                });

            modelBuilder.Entity("WebCode.Models.Demanda", b =>
                {
                    b.HasOne("WebCode.Models.Origem", "Origem")
                        .WithMany("Demandas")
                        .HasForeignKey("OrigemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
