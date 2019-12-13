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
        [Column("Id_Produto")]
        public int? IdProduto { get; set; }
        [Column("Id_Usuario")]
        public int? IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string NomeProduto { get; set; }
        [Required]
        [StringLength(255)]
        public string Quantidade { get; set; }
        [Column(TypeName = "money")]
        public decimal Preco { get; set; }
        [Required]
        [Column("Descricao_do_Produto")]
        [StringLength(255)]
        public string DescricaoDoProduto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Validade { get; set; }
        [Required]
        [Column("Foto_Url_Oferta", TypeName = "text")]
        public string FotoUrlOferta { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.Oferta))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Oferta))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
