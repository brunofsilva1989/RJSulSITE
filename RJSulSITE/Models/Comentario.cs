namespace RJSulSITE.Models
{
    public class Comentario
    {
        public int ComentarioID { get; set; }
        public int TopicoID { get; set; } // Relacionamento com o tópico
        public int UsuarioID { get; set; } // Relacionamento com o usuário que comentou
        public string Conteudo { get; set; }
        public DateTime DataComentario { get; set; } = DateTime.Now;

        // Navegação
        public Topico Topico { get; set; }
        public Usuario Usuario { get; set; }
    }
}
