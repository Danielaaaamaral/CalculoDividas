using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financeiro.WebAPI.Contexto;
using Financeiro.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IRepositorioFinanceiro _repositorioFinanceiro;

        public UsuarioController()
        {
            this._repositorioFinanceiro = new RepositorioFinanceiro(new FinanceiroContext());
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public  async Task<List<Usuario>> Get()
        {
            try {
                return await _repositorioFinanceiro.BuscarTodosUsuarios();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<Usuario> Get(int id)
        {
            try
            {
                return await _repositorioFinanceiro.BuscarUsuarioPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<Usuario> Post([FromBody] Usuario usuario)
        {
            try
            {
                return await _repositorioFinanceiro.AdicionarUsuario(usuario);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                 await _repositorioFinanceiro.DeletarUsuario(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
