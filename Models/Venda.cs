using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace tech_test_payment_api.Models
{
    [Table("Venda")]
    public class Venda
    {
        public Venda(){}

        [Key()]
        public int VendaId { get; set; }

        public DateTime DataDaVenda { get { return DateTime.Now; } }

        public string Produtos { get; set; }

        public int StatusCode { get; set; }

        public string Status { get; set; }

        [ForeignKey("VendedorId")]
        public int VendedorId { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}