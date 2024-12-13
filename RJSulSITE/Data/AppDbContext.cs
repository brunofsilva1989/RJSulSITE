using Microsoft.EntityFrameworkCore;
using RJSulSITE.Models;



namespace RJSulSITE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<OportunidadeEmprego> OportunidadesEmprego { get; set; }
        public DbSet<Comentario> Comentarios { get; set; } // Adicionando a tabela Comentarios

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>()
                .Property(s => s.Preco)
                .HasColumnType("decimal(18,2)"); // Especifica o tipo de coluna decimal com precisão e escala

            // Ajustar Comentarios para evitar cascata
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Topico)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TopicoID)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata

            //modelBuilder.Entity<Comentario>()
            //    .HasOne(c => c.Usuario)
            //    .WithMany(u => u.Comentarios)
            //    .HasForeignKey(c => c.UsuarioID)
            //    .OnDelete(DeleteBehavior.Restrict); // Evitar cascata
        }
    }
}
