using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class Projeto
    {
        public Projeto()
        {
            Equipe = new HashSet<Equipe>();
        }

        public int ProjetoId { get; set; }
        public int ClienteId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column(TypeName = "date")]
        public DateTime Prazo { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFinalizacao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataCriacao { get; set; }
        public int GerenteId { get; set; }

        [ForeignKey("ClienteId")]
        [InverseProperty("Projeto")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("GerenteId")]
        [InverseProperty("Projeto")]
        public virtual Usuario Gerente { get; set; }
        [InverseProperty("Projeto")]
        public virtual ICollection<Equipe> Equipe { get; set; }
    }
}