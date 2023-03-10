using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    [Table("Equipamentos")]
    public class EquipamentoModel
    {
        [Key]
        public int EquipamentoId{ get; set; }
        [Required, MaxLength(20)]
        public string Tag { get; set; }
        [Required, MaxLength(100)]
        public string Modelo { get; set; }
        [Required, MaxLength(50)]
        public string Status { get; set; }
        [Required, MaxLength(20)]
        public string Operando { get; set; }
        [MaxLength(20)]
        public string Obs { get; set; }
        public ICollection<MovimentoModel> MovimentosModel { get; set; }

        public EquipamentoModel()
        {
            this.Status = "Estoque";
            this.Operando = "Sim";
        }

    }
}