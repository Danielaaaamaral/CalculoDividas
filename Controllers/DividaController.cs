using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financeiro.WebAPI.Contexto;
using Financeiro.WebAPI.Model;
using Financeiro.WebAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DividaController : ControllerBase
    {
        private IRepositorioFinanceiro _repositorioFinanceiro;

        public DividaController()
        {
            this._repositorioFinanceiro = new RepositorioFinanceiro(new FinanceiroContext());
        }

        // GET: api/<DividaController>
        [HttpGet]
        public async Task<List<Divida>> Get()
        {
            try
            {
                return await _repositorioFinanceiro.BuscarTodosDividas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET api/<DividaController>/5
        [HttpGet("{id}")]
        public async Task<Divida> Get(int id)
        {
            try
            {
                return await _repositorioFinanceiro.BuscarDividaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        // GET api/<DividaController>/calculo
        [HttpGet("{calculo}")]
        public async Task<DividaRespostaViewModel> Calculo([FromBody] DividaViewModel divida)
        {
            try
            {
                return await _repositorioFinanceiro.CalcularDivida(divida);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // POST api/<DividaController>
        [HttpPost]
        public async Task<Divida> Post([FromBody] Divida divida)
        {
            try
            {
                return await _repositorioFinanceiro.AdicionarDivida(divida);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT api/<DividaController>/5
        [HttpPut("{id}")]
        public async Task<Divida> Put( [FromBody] Divida divida)
        {
            try
            {
                return await _repositorioFinanceiro.AtualizarDivida(divida);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // DELETE api/<DividaController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _repositorioFinanceiro.DeletarDivida(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
