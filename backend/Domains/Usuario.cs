using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Oferta = new HashSet<Oferta>();
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        [Column("Id_Tipo_Usuario")]
        public int? IdTipoUsuario { get; set; }
        [Required]
        [Column("Nome_Razao_Social")]
        [StringLength(255)]
        public string NomeRazaoSocial { get; set; }
        [Required]
        [Column("CPF_CNPJ")]
        [StringLength(14)]
        public string CpfCnpj { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Senha { get; set; }
        [Required]
        [Column("Celular_Telefone")]
        [StringLength(255)]
        public string CelularTelefone { get; set; }
        [Column("Foto_Url_Usuario", TypeName = "text")]
        public string FotoUrlUsuario { get; set; }
        [Required]
        [Column("Rua_Av")]
        [StringLength(255)]
        public string RuaAv { get; set; }
        public int Numero { get; set; }
        [Required]
        [StringLength(255)]
        public string Complemento { get; set; }
        [Required]
        [Column("CEP")]
        [StringLength(9)]
        public string Cep { get; set; }
        [Required]
        [StringLength(255)]
        public string Bairro { get; set; }
        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuario.Usuario))]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Oferta> Oferta { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
