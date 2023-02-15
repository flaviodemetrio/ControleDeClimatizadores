using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class MovimentoModel
    {
        [Key]
        public int IdMovimento { get; set; }
        public DateTime? DataMovimento { get; set; }
        [Required, MaxLength(20)]
        public string TipoMovimento { get; set; }
        public string NumeroContrato { get; set; }
        public ClienteModel cliente { get; set; }
        public DateTime? InicioLocacao { get; set; }
        public DateTime? FimLocacao { get; set; }
        public EquipamentoModel Equipamento{get;set;}
        public List<EquipamentoModel> Equipamentoslista{get;set;}
                
        public string Obs { get; set; }        

    }    
}