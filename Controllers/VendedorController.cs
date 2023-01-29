using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly ApiContext _dbcontext;

        public VendedorController(ApiContext context){
            _dbcontext = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Vendedor vendedor){

            _dbcontext.Add(vendedor);
            _dbcontext.SaveChanges();

            return Ok(vendedor);
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var dbVendedor = _dbcontext.Vendedores;

            return Ok(dbVendedor);
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Vendedor vendedor){

            var dbVendedor = _dbcontext.Vendedores.Find(id);

            if(dbVendedor == null){
                return NotFound();
            }

            dbVendedor.Nome = vendedor.Nome;
            dbVendedor.Cpf = vendedor.Cpf;
            dbVendedor.Email = vendedor.Email;
            dbVendedor.Telefone = vendedor.Telefone;
            
            _dbcontext.SaveChanges();

            return Ok(dbVendedor);
        }

        [HttpDelete]
        public IActionResult Deletar(int id){
            var dbVendedor = _dbcontext.Vendedores.Find(id);

            if(dbVendedor == null){
                return NotFound();
            }

            _dbcontext.Remove(dbVendedor);
            _dbcontext.SaveChanges();

            return NoContent();
        }
    }
}