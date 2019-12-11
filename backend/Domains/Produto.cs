using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Oferta = new HashSet<Oferta>();
            Pedido = new HashSet<Pedido>();
            ProdutoReceita = new HashSet<ProdutoReceita>();
        }

        [Key]
        [Column("Id_Produto")]
        public int IdProduto { get; set; }
        [Required]
        [StringLength(255)]
        public string NomeProduto { get; set; }
        [Required]
        [Column("Descricao_do_Produto")]
        [StringLength(255)]
        public string DescricaoDoProduto { get; set; }
        [Column("Id_Cat_Produto")]
        public int? IdCatProduto { get; set; }

        [ForeignKey(nameof(IdCatProduto))]
        [InverseProperty(nameof(CatProduto.Produto))]
        public virtual CatProduto IdCatProdutoNavigation { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<Oferta> Oferta { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<ProdutoReceita> ProdutoReceita { get; set; }
    }
}
