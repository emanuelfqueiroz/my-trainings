using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class Cargo
    {
        public Cargo()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int CargoId { get; set; }
        [Required]
        [Column("Cargo")]
        [StringLength(50)]
        public string Nome { get; set; }

        [InverseProperty("Cargo")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}