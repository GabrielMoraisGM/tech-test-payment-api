using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Vendedor vendedor;
        public int Produtos { get; set; }
        public EnumStatusVenda Status;
    }
}