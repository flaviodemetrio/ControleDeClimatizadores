using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    [Table("Movimentos")]
    public class MovimentoModel
    {
        [Key]
        public int MovimentoId { get; set; }
        public string DataMovimento { get; set; }
        [Required, MaxLength(20)]
        public string TipoMovimento { get; set; }
        [Required, MaxLength(20)]
        public string NumeroContrato { get; set; }
        public int ClienteId { get; set; }
        public ClienteModel cliente { get; set; }
        [Required, MaxLength(20)]
        public string InicioLocacao { get; set; }
        [Required, MaxLength(20)]
        public string FimLocacao { get; set; }
        public string Obs { get; set; }
        public ICollection<EquipamentoModel> EquipamentosModel { get; set; }

    }
}