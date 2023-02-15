using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class ClienteModel
    {
        [Key]
        public int IdCliente { get; set; }
        [Required, MaxLength(20)]
        public string Cnpj { get; set; }
        [Required, MaxLength(80)]
        public string RazaoSocial { get; set; }
        [Required, MaxLength(80)]
        public string Fantasia { get; set; }
        [Required, MaxLength(20)]
        public string Cep { get; set; }
        [Required, MaxLength(100)]
        public string Endereco { get; set; }
        [Required, MaxLength(50)]
        public string numero { get; set; }
        [ MaxLength(100)]
        public string Complemento { get; set; }
        [Required, MaxLength(100)]
        public string Bairro { get; set; }
        [Required, MaxLength(100)]
        public string Cidade { get; set; }
        [Required, MaxLength(10)]
        public string Estado { get; set; }
    }   
}