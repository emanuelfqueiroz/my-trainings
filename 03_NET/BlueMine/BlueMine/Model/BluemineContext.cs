using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlueMine.Model
{
    public partial class BluemineContext : DbContext
    {
        public BluemineContext()
        {
        }

        public BluemineContext(DbContextOptions<BluemineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Equipe> Equipe { get; set; }
        public virtual DbSet<Projeto> Projeto { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }
        public virtual DbSet<TarefaHistorico> TarefaHistorico { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2AIRPK8;Initial Catalog=BlueMine;User ID=application;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Cnpj).IsUnicode(false);

                entity.Property(e => e.Cpf).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Fone1).IsUnicode(false);

                entity.Property(e => e.Fone2).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.NomeFantasia).IsUnicode(false);

                entity.Property(e => e.Situacao).IsUnicode(false);
            });

            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.HasOne(d => d.Projeto)
                    .WithMany(p => p.Equipe)
                    .HasForeignKey(d => d.ProjetoId)
                    .HasConstraintName("FK_Equipe_Projeto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Equipe)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Equipe_Usuario");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Projeto)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projeto_Cliente");

                entity.HasOne(d => d.Gerente)
                    .WithMany(p => p.Projeto)
                    .HasForeignKey(d => d.GerenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gerente_Projeto_Usuario");
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Situacao).IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Tarefa_Usuario");
            });

            modelBuilder.Entity<TarefaHistorico>(entity =>
            {
                entity.HasKey(e => new { e.TarefaId, e.DataRegistro });

                entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).IsUnicode(false);

                entity.HasOne(d => d.Tarefa)
                    .WithMany(p => p.TarefaHistorico)
                    .HasForeignKey(d => d.TarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarefaHistorico_Tarefa");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Cpf).IsUnicode(false);

                entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Fone).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Sexo).IsUnicode(false);

                entity.Property(e => e.Situacao).IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Cargo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}