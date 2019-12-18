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
                optionsBuilder.UseSqlServer("Server=LAPTOP-P3KQSPPA;Database=fastrade;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatProduto>(entity =>
            {
                entity.HasKey(e => e.IdCatProduto)
                    .HasName("PK__Cat_Prod__27A1E38D02DA0A96");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__Cat_Prod__8E762CB4215A3308")
                    .IsUnique();

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOferta)
                    .HasName("PK__Oferta__6C9F2EA0C13B4C84");

                entity.Property(e => e.DescricaoDoProduto).IsUnicode(false);

                entity.Property(e => e.NomeProduto).IsUnicode(false);

                entity.Property(e => e.Quantidade).IsUnicode(false);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Oferta__Id_Produ__5DCAEF64");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Oferta__Id_Usuar__5EBF139D");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__A5D0013928A1215F");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Pedido__Id_Produ__59FA5E80");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pedido__Id_Usuar__5AEE82B9");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__94E704D8E625386F");

                entity.HasOne(d => d.IdCatProdutoNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCatProduto)
                    .HasConstraintName("FK__Produto__Id_Cat___4E88ABD4");
            });

            modelBuilder.Entity<ProdutoReceita>(entity =>
            {
                entity.HasKey(e => e.IdProdutoReceita)
                    .HasName("PK__Produto___ADAB9BA852FF93AF");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoReceita)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Produto_R__Id_Pr__534D60F1");

                entity.HasOne(d => d.IdReceitaNavigation)
                    .WithMany(p => p.ProdutoReceita)
                    .HasForeignKey(d => d.IdReceita)
                    .HasConstraintName("FK__Produto_R__Id_Re__5441852A");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasKey(e => e.IdReceita)
                    .HasName("PK__Receita__22C967301E598335");

                entity.Property(e => e.NomeReceita).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__Tipo_Usu__689D5FEA07D7EA45");

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE22DBACA10");

                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.CelularTelefone).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.CpfCnpj).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeRazaoSocial).IsUnicode(false);

                entity.Property(e => e.RuaAv).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__Id_Tipo__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
