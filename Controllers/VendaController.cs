using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendaController : ControllerBase
    {
        private readonly ApiContext _dbcontext;

        public VendaController(ApiContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("CadastrarVenda")]
        public async Task<IActionResult> Cadastrar(Venda venda)
        {
            Venda novaVenda = new Venda();
            Status status = new Status();

            novaVenda.VendaId = venda.VendaId;
            novaVenda.Produtos = venda.Produtos;
            novaVenda.VendedorId = venda.VendedorId;
            novaVenda.Vendedor = await _dbcontext.Vendedores.FindAsync(venda.VendedorId);
            novaVenda.StatusCode = 0;
            novaVenda.Status = status.StatusName[0];

            _dbcontext.Vendas.Add(novaVenda);
            _dbcontext.SaveChanges();

            return Ok(novaVenda);
        }

        [HttpGet("ConsultarCadastros")]
        public IActionResult Consultar(){

            var dbvenda = _dbcontext.Vendas.Include(x => x.Vendedor);

            foreach (var item in dbvenda)
            {
                item.Vendedor = _dbcontext.Vendedores.FirstOrDefault(ven => ven.VendedorId.Equals(item.VendedorId));
            }

            return Ok(dbvenda);
        }

        [HttpGet("ConsultarPorId")]
        public IActionResult ConsultarId(int id){

            var dbVendedor = _dbcontext.Vendas.Include(x => x.Vendedor);

            foreach (var item in dbVendedor)
            {
                item.Vendedor = _dbcontext.Vendedores.FirstOrDefault(ven => ven.VendedorId.Equals(item.VendedorId));
            }

            var dbVenda = _dbcontext.Vendas.Find(id);

            return Ok(dbVenda);
        }

        [HttpPut("AtualizarVenda")]
        public IActionResult Atualizar(int id, Venda venda)
        {

            var dbVenda = _dbcontext.Vendas.Find(id);
            Status status = new Status();

            if(dbVenda.StatusCode == 0 && (venda.StatusCode == 1 || venda.StatusCode == 2)){
                dbVenda.StatusCode = venda.StatusCode;
                dbVenda.Status = status.StatusName[venda.StatusCode];
            }
    
            else if(dbVenda.StatusCode == 1 && venda.StatusCode == 3 || venda.StatusCode == 2){
                dbVenda.StatusCode = venda.StatusCode;
                dbVenda.Status = status.StatusName[venda.StatusCode];
            }
            else if(dbVenda.StatusCode == 3 && venda.StatusCode == 4){
                dbVenda.StatusCode = venda.StatusCode;
                dbVenda.Status = status.StatusName[venda.StatusCode];
            }

            _dbcontext.Vendas.Update(dbVenda);
            _dbcontext.SaveChanges();
            
            return Ok();
        }
    }
}