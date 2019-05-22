using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class Tarefa
    {
        public Tarefa()
        {
            TarefaHistorico = new HashSet<TarefaHistorico>();
        }

        public int TarefaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(200)]
        public string Descricao { get; set; }
        public byte Prioridade { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime Prazo { get; set; }
        [Required]
        [StringLength(1)]
        public string Situacao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataFinalizacao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataCriacao { get; set; }
        public int ProjetoId { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [InverseProperty("Tarefa")]
        public virtual Usuario Usuario { get; set; }
        [InverseProperty("Tarefa")]
        public virtual ICollection<TarefaHistorico> TarefaHistorico { get; set; }
    }
}