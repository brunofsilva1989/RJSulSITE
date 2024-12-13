using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJSulSITE.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }   
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Descricao { get; set; }
    }
}
