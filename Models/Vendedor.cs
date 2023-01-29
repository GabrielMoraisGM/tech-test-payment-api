using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tech_test_payment_api.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Key()]
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public ulong Cpf { get; set; }
        public string Email { get; set; }
        public ulong Telefone { get; set; }
    }
}