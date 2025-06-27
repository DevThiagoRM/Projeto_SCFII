using Microsoft.EntityFrameworkCore;
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
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TiposTelefone { get; set; }
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

                entity.HasData(
                    new Cargo { Id = 1, NomeCargo = "Desenvolvedor" }
                );
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamentos");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeDepartamento)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasData(
                    new Departamento { Id = 1, NomeDepartamento = "Departamento de TI" }
                );
            });

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Usuario)
                .WithOne(u => u.Endereco)
                .HasForeignKey<Endereco>(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Generos");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeGenero)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(300);

                entity.HasData(
                    new Genero { Id = 1, NomeGenero = "Masculino", Descricao = "Homem cisgênero" },
                    new Genero { Id = 2, NomeGenero = "Feminino", Descricao = "Mulher cisgênero" },
                    new Genero { Id = 3, NomeGenero = "Não binário", Descricao = "Pessoa que não se identifica dentro do binário homem/mulher" },
                    new Genero { Id = 4, NomeGenero = "Transgênero Homem", Descricao = "Pessoa trans identificada como homem" },
                    new Genero { Id = 5, NomeGenero = "Transgênero Mulher", Descricao = "Pessoa trans identificada como mulher" },
                    new Genero { Id = 6, NomeGenero = "Gênero Fluído", Descricao = "Pessoa cuja identidade de gênero varia com o tempo" },
                    new Genero { Id = 7, NomeGenero = "Agênero", Descricao = "Pessoa sem identidade de gênero definida" },
                    new Genero { Id = 8, NomeGenero = "Intersexo", Descricao = "Pessoa com características sexuais diversas" },
                    new Genero { Id = 9, NomeGenero = "Prefere não dizer", Descricao = "Pessoa que opta por não declarar o gênero" }
                );
            });

            modelBuilder.Entity<Raca>(entity =>
            {
                entity.ToTable("Racas");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NomeRaca)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasData(
                    new Raca { Id = 1, NomeRaca = "Branca" },
                    new Raca { Id = 2, NomeRaca = "Preta" },
                    new Raca { Id = 3, NomeRaca = "Parda" },
                    new Raca { Id = 4, NomeRaca = "Amarela" },
                    new Raca { Id = 5, NomeRaca = "Indígena" },
                    new Raca { Id = 6, NomeRaca = "Prefere não dizer" }
                );
            });

            modelBuilder.Entity<StatusUsuario>(entity =>
            {
                entity.ToTable("StatusUsuario");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasData(
                    new StatusUsuario { Id = 1, Status = "Ativo" },
                    new StatusUsuario { Id = 2, Status = "Bloqueado" },
                    new StatusUsuario { Id = 3, Status = "Inativo" }
                );
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasData(
                    new TipoUsuario { Id = 1, TipoDeUsuario = "Administrador" },
                    new TipoUsuario { Id = 2, TipoDeUsuario = "Gerência" },
                    new TipoUsuario { Id = 3, TipoDeUsuario = "Usuario Comum" }
                );
            });

            modelBuilder.Entity<Telefone>()
                        .HasOne(t => t.TipoTelefone)
                        .WithMany(tt => tt.Telefones)
                        .HasForeignKey(t => t.TipoTelefoneId);


            modelBuilder.Entity<TipoTelefone>(entity =>
            {
                entity.ToTable("TiposTelefone");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.TipoDeTelefone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasData(
                    new TipoTelefone { Id = 1, TipoDeTelefone = "Telefone Fixo" },
                    new TipoTelefone { Id = 2, TipoDeTelefone = "Celular" }
                );
            });
        }
    }
}
