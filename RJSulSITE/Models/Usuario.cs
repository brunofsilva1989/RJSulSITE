using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJSulSITE.Models
{
    public class Usuario
    {

        public Usuario()
        {
            DataCadastro = DateTime.Now;
        }

        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um endereço de email válido.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]        
        public string Senha { get; set; }
       
        [Required(ErrorMessage = "O campo Tipo de Usuário é obrigatório.")]
        public string TipoUsuario { get; set; }
        
        public DateTime DataCadastro { get; set; }
        //public virtual ICollection<Comentario> Comentarios { get; set; }
    }

}
