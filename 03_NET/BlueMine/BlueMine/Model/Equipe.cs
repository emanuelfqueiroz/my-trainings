using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class Equipe
    {
        public int EquipeId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        [InverseProperty("Equipe")]
        public virtual Projeto Projeto { get; set; }
        [ForeignKey("UsuarioId")]
        [InverseProperty("Equipe")]
        public virtual Usuario Usuario { get; set; }
    }
}