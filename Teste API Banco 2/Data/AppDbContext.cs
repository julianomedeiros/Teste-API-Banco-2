using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Teste_API_Banco_2.Models;

namespace Teste_API_Banco_2.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<TabBanco> TabBanco { get; set; }
        public virtual DbSet<TabCliente> TabCliente { get; set; }
        public virtual DbSet<TabHistorico> TabHistorico { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabBanco>(entity =>
            {
                entity.HasKey(e => e.IdBanco).HasName("PK__tab_Banc__D8FFCB75443A8FF1");

                entity.ToTable("tab_Banco");

                entity.Property(e => e.IdBanco).HasColumnName("idBanco");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Saldo).HasColumnName("saldo");
            });

            modelBuilder.Entity<TabCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__tab_Clie__885457EE2018CE6A");

                entity.ToTable("tab_Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnName("saldo");
            });

            modelBuilder.Entity<TabHistorico>(entity =>
            {
                entity.HasKey(e => e.Idhistorico)
                    .HasName("PK__tab_Hist__E931C024244BE9F2");

                entity.ToTable("tab_Historico");

                entity.Property(e => e.Idhistorico).HasColumnName("idhistorico");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NomeDoTitular)
                    .IsRequired()
                    .HasColumnName("nomeDoTitular")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ValorFinal).HasColumnName("valorFinal");

                entity.Property(e => e.ValorMovimentacao).HasColumnName("valorMovimentacao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
