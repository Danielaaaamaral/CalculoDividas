using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Financeiro.WebAPI.Contexto;
using Financeiro.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IRepositorioFinanceiro _repositorioFinanceiro;

        public ClienteController()
        {
            this._repositorioFinanceiro = new RepositorioFinanceiro(new FinanceiroContext());
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Cliente>>  Get()
        {
            try
            {
                return await _repositorioFinanceiro.BuscarTodosClientes();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id)
        {
            try
            {
                return await _repositorioFinanceiro.BuscarClientePorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Cliente> Post([FromBody] Cliente cliente)
        {
            try
            {
                return await _repositorioFinanceiro.AdicionarCliente(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<Cliente> Put( [FromBody] Cliente cliente)
        {
            try
            {
                return await _repositorioFinanceiro.AtualizarCliente(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _repositorioFinanceiro.DeletarCliente(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
