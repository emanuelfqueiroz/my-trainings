using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class TarefaHistorico
    {
        public int TarefaId { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime DataRegistro { get; set; }
        [Required]
        [StringLength(1)]
        public string Situacao { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("TarefaId")]
        [InverseProperty("TarefaHistorico")]
        public virtual Tarefa Tarefa { get; set; }
    }
}