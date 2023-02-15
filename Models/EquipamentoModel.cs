using System;
using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class EquipamentoModel
    {
        [Key]
        public int IdEquipamento { get; set; }
        [Required, MaxLength(20)]
        public string Tag { get; set; }
        [Required, MaxLength(100)]
        public string Modelo { get; set; }
        [Required, MaxLength(50)]
        public string Status { get; set; }
        [Required, MaxLength(20)]
        public string Operando { get; set; }
        [MaxLength(20)]
        public string NumeroContrato { get; set; }
        public ClienteModel cliente { get; set; }
        public DateTime? InicioLocacao { get; set; }
        public DateTime? FimLocacao { get; set; }
        public string Obs { get; set; }    


        public EquipamentoModel()
        {
            this.Status = "Estoque";
            this.Operando = "Sim";
        }

    }    
}