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

                entity.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasData(
                    new Genero { Id = 1, NomeGenero = "Masculino", Descricao = "Homem cisgênero"},
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

                entity.HasData(
                    new TipoEndereco { Id = 1, TipoDeEndereco = "Residencial" },
                    new TipoEndereco { Id = 2, TipoDeEndereco = "Comercial" },
                    new TipoEndereco { Id = 3, TipoDeEndereco = "Cobrança" }
                );
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.TipoDeUsuario)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasData(
                    new TipoUsuario { Id = 1, TipoDeUsuario = "Administrador" },
                    new TipoUsuario { Id = 2, TipoDeUsuario = "Gerente" },
                    new TipoUsuario { Id = 3, TipoDeUsuario = "Usuário Comum" }
                );
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

                entity.HasIndex(u => u.Email).IsUnique();


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
