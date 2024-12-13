using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJSulSITE.Models
{
    public class Topico
    {
        public int TopicoId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }

        [MaxLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
        public string Descricao { get; set; }  // Descrição com tamanho máximo de 200

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        public string Conteudo { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }  // Definido como obrigatório

        public int UsuarioId { get; set; }  // Relacionamento com o Usuário
        public Usuario Usuario { get; set; }  // Relacionamento (Foreign Key)
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
