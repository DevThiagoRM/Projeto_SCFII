using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Relacionamento Entidade-Tabela

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<TipoEndereco> TiposEndereco { get; set; }
        public DbSet<UsuarioEndereco> UsuariosEnderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TiposTelefone { get; set; }
        public DbSet<UsuarioTelefone> UsuariosTelefones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<StatusUsuario> StatusUsuarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Raca> Racas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de relacionamento e propriedades adicionais

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargos");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeCargo)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamentos");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeDepartamento)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Enderecos");
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.TipoEndereco)
                      .WithMany(t => t.Enderecos)
                      .HasForeignKey(c => c.TipoEnderecoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(c => c.UF)
                .IsRequired()
                .HasMaxLength(2);

                entity.Property(c => c.TipoEnderecoId)
                .IsRequired();

                entity.Property(c => c.Referencia)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Generos");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeGenero)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Raca>(entity =>
            {
                entity.ToTable("Racas");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeRaca)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<StatusUsuario>(entity =>
            {
                entity.ToTable("StatusUsuario");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("Telefones");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.NumeroTelefone)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(c => c.TipoTelefoneId)
                .IsRequired();
            });

            modelBuilder.Entity<TipoEndereco>(entity =>
            {
                entity.ToTable("TipoEndereco");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.TipoDeEndereco)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.TipoDeUsuario)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nome)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.Sobrenome)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Ignore(c => c.NomeCompleto);

                entity.Property(c => c.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.Senha)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.DataCriacao)
                      .IsRequired();

                entity.Property(c => c.DataAdmissao)
                      .IsRequired();

                entity.Property(c => c.Deleted)
                      .IsRequired();

                // Relacionamentos FK
                entity.HasOne(u => u.Cargo)
                      .WithMany(c => c.Usuarios)
                      .HasForeignKey(u => u.CargoId)
                      .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(u => u.Departamento)
                      .WithMany(d => d.Usuarios)
                      .HasForeignKey(u => u.DepartamentoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Raca)
                      .WithMany(r => r.Usuarios)
                      .HasForeignKey(u => u.RacaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Genero)
                      .WithMany(g => g.Usuarios)
                      .HasForeignKey(u => u.GeneroId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.StatusUsuario)
                      .WithMany(s => s.Usuarios)
                      .HasForeignKey(u => u.StatusUsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.TipoUsuario)
                      .WithMany(t => t.Usuarios)
                      .HasForeignKey(u => u.TipoUsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // Entidades Associativas

            modelBuilder.Entity<UsuarioEndereco>(entity =>
            {
                entity.ToTable("UsuariosEnderecos");
                entity.HasKey(ue => new { ue.UsuarioId, ue.EnderecoId }); // Chave composta

                entity.HasOne(ue => ue.Usuario)
                    .WithMany(u => u.UsuarioEndereco)
                    .HasForeignKey(ue => ue.UsuarioId);

                entity.HasOne(ue => ue.Endereco)
                    .WithMany(e => e.UsuarioEndereco)
                    .HasForeignKey(ue => ue.EnderecoId);
            });

            modelBuilder.Entity<UsuarioTelefone>(entity =>
            {
                entity.ToTable("UsuariosTelefones");
                entity.HasKey(ue => new { ue.UsuarioId, ue.TelefoneId }); // Chave composta

                entity.HasOne(ue => ue.Usuario)
                    .WithMany(u => u.UsuarioTelefone)
                    .HasForeignKey(ue => ue.UsuarioId);

                entity.HasOne(ue => ue.Telefone)
                    .WithMany(e => e.UsuarioTelefone)
                    .HasForeignKey(ue => ue.TelefoneId);
            });

            base.OnModelCreating(modelBuilder);

        }

    }
}
