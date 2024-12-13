using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJSulSITE.Models
{
    public class OportunidadeEmprego
    {
        public OportunidadeEmprego()
        {
            DataCriacao = DateTime.Now;
        }

        [Key]
        public int OportunidadeID { get; set; }
        
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Descricao { get; set; } // Campo opcional

        [StringLength(255)]
        public string? Localizacao { get; set; } // Campo opcional

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salario { get; set; } // Campo opcional
        
        public DateTime DataCriacao { get; set; }

        // Propriedade de navegação
        [ForeignKey("UsuarioID")]
        public Usuario? Usuario { get; set; }
    }
}
