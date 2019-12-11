using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Oferta
    {
        [Key]
        [Column("Id_Oferta")]
        public int IdOferta { get; set; }
        [Required]
        [Column("Nome_Produto")]
        [StringLength(255)]
        public string NomeProduto { get; set; }
        [Required]
        [Column("Descricao_do_Produto")]
        [StringLength(255)]
        public string DescricaoDoProduto { get; set; }
        [Required]
        [StringLength(255)]
        public string Quantidade { get; set; }
        [Column(TypeName = "money")]
        public decimal Preco { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Validade { get; set; }
        [Required]
        [Column("Foto_Url_Oferta", TypeName = "text")]
        public string FotoUrlOferta { get; set; }
        [Column("Id_Produto")]
        public int? IdProduto { get; set; }
        [Column("Id_Usuario")]
        public int? IdUsuario { get; set; }
        [Column("Id_Cat_Produto")]
        public int? IdCatProduto { get; set; }

        [ForeignKey(nameof(IdCatProduto))]
        [InverseProperty(nameof(CatProduto.Oferta))]
        public virtual CatProduto IdCatProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.Oferta))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Oferta))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
