using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Status
    {
        public List<string> StatusName = new List<string>() 
        { 
            "Aguardando Pagamento",
            "Pagamento Aprovado", 
            "Cancelada",
            "Enviado para Transportadora",
            "Entregue"
        };
    }
}