namespace $safeprojectname$.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class baseDados : DbContext
    {
        public baseDados()
            : base("name=baseDados")
        {
        }

        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Possui> Possui { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<Solicita> Solicita { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingrediente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Ingrediente>()
                .HasMany(e => e.Possui)
                .WithRequired(e => e.Ingrediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.Dificuldade)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.Preparacao)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.Video)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.Foto)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .HasMany(e => e.Possui)
                .WithRequired(e => e.Receita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receita>()
                .HasMany(e => e.Solicita)
                .WithRequired(e => e.Receita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicita>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .HasMany(e => e.Solicita)
                .WithRequired(e => e.Utilizador)
                .WillCascadeOnDelete(false);
        }
    }
}
