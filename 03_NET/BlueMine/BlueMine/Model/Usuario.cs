using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMine.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Equipe = new HashSet<Equipe>();
            Projeto = new HashSet<Projeto>();
            Tarefa = new HashSet<Tarefa>();
        }

        public int UsuarioId { get; set; }
        [Required]
        [Column("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(20)]
        public string Fone { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }
        public int CargoId { get; set; }
        [Required]
        [StringLength(1)]
        public string Situacao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataCriacao { get; set; }

        [ForeignKey("CargoId")]
        [InverseProperty("Usuario")]
        public virtual Cargo Cargo { get; set; }
        [InverseProperty("Usuario")]
        public virtual ICollection<Equipe> Equipe { get; set; }
        [InverseProperty("Gerente")]
        public virtual ICollection<Projeto> Projeto { get; set; }
        [InverseProperty("Usuario")]
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}