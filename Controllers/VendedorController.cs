using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly VendedorContext _vendedorcontext;

        public VendedorController(VendedorContext vendedor){
            _vendedorcontext = vendedor;
        }

        [HttpPost]
        public IActionResult Cadastrar(Vendedor vendedor)
        {
            _vendedorcontext.Add(vendedor);
            _vendedorcontext.SaveChanges();

            return Ok(vendedor);
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var dbVendedor = _vendedorcontext.Vendedores;

            return Ok(dbVendedor);
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Vendedor vendedor){

            var dbVendedor = _vendedorcontext.Vendedores.Find(id);

            if(dbVendedor == null){
                return NotFound();
            }

            dbVendedor.Nome = vendedor.Nome;
            dbVendedor.Cpf = vendedor.Cpf;
            dbVendedor.Email = vendedor.Email;
            dbVendedor.Telefone = vendedor.Telefone;

            _vendedorcontext.SaveChanges();

            return Ok(dbVendedor);
        }

        [HttpDelete]
        public IActionResult Deletar(int id){
            var dbVendedor = _vendedorcontext.Vendedores.Find(id);

            if(dbVendedor == null){
                return NotFound();
            }

            _vendedorcontext.Remove(dbVendedor);
            _vendedorcontext.SaveChanges();

            return NoContent();
        }
    }
}