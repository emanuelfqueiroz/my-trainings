using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            Projeto = new HashSet<Projeto>();
        }

        public int ClienteId { get; set; }
        [Column("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Column("CNPJ")]
        [StringLength(14)]
        public string Cnpj { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeFantasia { get; set; }
        [Required]
        [StringLength(20)]
        public string Fone1 { get; set; }
        [Required]
        [StringLength(20)]
        public string Fone2 { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(1)]
        public string Situacao { get; set; }

        [InverseProperty("Cliente")]
        public virtual ICollection<Projeto> Projeto { get; set; }
    }
}