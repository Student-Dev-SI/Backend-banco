using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Domains
{
    public partial class fastradeContext : DbContext
    {
        public fastradeContext()
        {
        }

        public fastradeContext(DbContextOptions<fastradeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatProduto> CatProduto { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoReceita> ProdutoReceita { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-D4CE51M\\SQLEXPRESS; Database=fastrade; User Id=sa; Password=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatProduto>(entity =>
            {
                entity.HasKey(e => e.IdCatProduto)
                    .HasName("PK__Cat_Prod__27A1E38D147F3F37");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__Cat_Prod__8E762CB447E751E2")
                    .IsUnique();

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__4B5640355D9DE626");

                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RuaAv).IsUnicode(false);
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOferta)
                    .HasName("PK__Oferta__6C9F2EA0294D6710");

                entity.Property(e => e.Preco).IsUnicode(false);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Oferta__Id_Produ__4E88ABD4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Oferta__Id_Usuar__4F7CD00D");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__A5D00139A342539B");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Pedido__Id_Produ__4AB81AF0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pedido__Id_Usuar__4BAC3F29");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__94E704D8D9761F2C");

                entity.Property(e => e.DescricaoDoProduto).IsUnicode(false);

                entity.Property(e => e.NomeProduto).IsUnicode(false);

                entity.Property(e => e.Quantidade).IsUnicode(false);

                entity.HasOne(d => d.IdCatProdutoNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCatProduto)
                    .HasConstraintName("FK__Produto__Id_Cat___3E52440B");
            });

            modelBuilder.Entity<ProdutoReceita>(entity =>
            {
                entity.HasKey(e => e.IdProdutoReceita)
                    .HasName("PK__Produto___ADAB9BA873DB8C1B");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoReceita)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Produto_R__Id_Pr__4316F928");

                entity.HasOne(d => d.IdReceitaNavigation)
                    .WithMany(p => p.ProdutoReceita)
                    .HasForeignKey(d => d.IdReceita)
                    .HasConstraintName("FK__Produto_R__Id_Re__440B1D61");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasKey(e => e.IdReceita)
                    .HasName("PK__Receita__22C967301FD3E03E");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__Tipo_Usu__689D5FEAC27D8BE8");

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE237A52E67");

                entity.Property(e => e.CelularTelefone).IsUnicode(false);

                entity.Property(e => e.CpfCnpj).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NomeRazaoSocial).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Usuario__Id_Ende__46E78A0C");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__Id_Tipo__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
