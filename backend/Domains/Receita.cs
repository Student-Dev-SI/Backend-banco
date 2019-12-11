using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Receita
    {
        public Receita()
        {
            ProdutoReceita = new HashSet<ProdutoReceita>();
        }

        [Key]
        [Column("Id_Receita")]
        public int IdReceita { get; set; }
        [Column("Nome_Receita")]
        [StringLength(255)]
        public string NomeReceita { get; set; }

        [InverseProperty("IdReceitaNavigation")]
        public virtual ICollection<ProdutoReceita> ProdutoReceita { get; set; }
    }
}
