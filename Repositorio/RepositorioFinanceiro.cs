using Financeiro.WebAPI.Model;
using Financeiro.WebAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.Contexto
{
    public class RepositorioFinanceiro : IRepositorioFinanceiro, IDisposable
    {
        private FinanceiroContext _contexto = null;
        #region Construtor

        public RepositorioFinanceiro(FinanceiroContext contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtor

        #region Cliente
        public async Task<List<Cliente>> BuscarTodosClientes() 
        {
            try {
                return await _contexto.Cliente.ToListAsync();
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
        public async Task<Cliente> BuscarClientePorId(long Id)
        {
            try
            {
                return await _contexto.Cliente.Where(x=>x.IdCliente==Id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            try
            {
                _contexto.Cliente.Add(cliente);
                await _contexto.SaveChangesAsync();
                return BuscarTodosClientes().Result.Where(x => x.CPF == cliente.CPF).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Cliente> AtualizarCliente(Cliente cliente)
        {
            try
            {
                _contexto.Cliente.Update(cliente);
                await _contexto.SaveChangesAsync();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task DeletarCliente(long id)
        {
            try
            {
                var cliente = BuscarTodosClientes().Result.Where(x => x.IdCliente == id).FirstOrDefault();
                _contexto.Cliente.Remove(cliente);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Divida
        public async Task<List<Divida>> BuscarTodosDividas()
        {
            try
            {
                return await _contexto.Divida.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Divida> BuscarDividaPorId(long Id)
        {
            try
            {
                return await _contexto.Divida.Where(x => x.IdDivida == Id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public double CalcularJurosSimples(double valorDivida,int dias, double vlrJuros) {
            try {
                
                return valorDivida * (1 + (0.2 * dias));
  
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public double CalcularJurosComposto(double valorDivida, int dias, double vlrJuros)
        {
            try
            {

                return  valorDivida *(1 + vlrJuros / 100)* dias;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public double CalcularComissao(double valorDividaJuros,double juros)
        {
            try
            {
                return (valorDividaJuros * juros);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public double CalcularVlrParcela(double valorDividaJuros, int qtdParcelas) {
            try
            {
                return valorDividaJuros / qtdParcelas;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int CalcularQtdDiasJuros(DateTime dataVencimento) {
            try
            {
                return DateTime.Now.Day - dataVencimento.Day;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<DividaRespostaViewModel> CalcularDivida(DividaViewModel dividaV)
        {
            try
            {
                double valorComJuros = 0;
                var divida = await BuscarDividaPorId(dividaV.IdDivida);
                var qtdDias = CalcularQtdDiasJuros(divida.DtaVencimento);

                if(dividaV.TipoJuros=="S")
                    valorComJuros = CalcularJurosSimples(divida.VlrDivida, qtdDias,dividaV.vlrJuros);
                else if(dividaV.TipoJuros == "C")
                    valorComJuros = CalcularJurosComposto(divida.VlrDivida, qtdDias, dividaV.vlrJuros);

                var comissao = CalcularComissao(valorComJuros,dividaV.Comissao);

                var valorParcelas = CalcularVlrParcela(valorComJuros, dividaV.QtdParcelas);

                DividaRespostaViewModel resposta = new DividaRespostaViewModel()
                {
                    DtaVencimento=divida.DtaVencimento,
                    VlrDivida=divida.VlrDivida,
                    QtdDiasJuros= qtdDias,
                    QtdParcelas=dividaV.QtdParcelas,
                    VlrTotalDivida= valorComJuros,
                    VlrParcela = valorParcelas,
                    TelContato=1111111111
                };

                return resposta;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Divida> AdicionarDivida(Divida divida)
        {
            try
            {
                _contexto.Divida.Add(divida);
                await _contexto.SaveChangesAsync();
                return BuscarTodosDividas().Result.Where(x => x.IdDivida == divida.IdDivida).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Divida> AtualizarDivida(Divida divida)
        {
            try
            {
                _contexto.Divida.Update(divida);
                await _contexto.SaveChangesAsync();
                return divida;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task DeletarDivida(long id)
        {
            try
            {
                var divida = BuscarTodosDividas().Result.Where(x => x.IdDivida == id).FirstOrDefault();
                _contexto.Divida.Remove(divida);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #region Usuario
        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            try
            {
                return await _contexto.Usuario.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Usuario> BuscarUsuarioPorId(long Id)
        {
            try
            {
                return await _contexto.Usuario.Where(x => x.IdUsuario == Id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                 _contexto.Usuario.Add(usuario);
                await _contexto.SaveChangesAsync();
                return  BuscarTodosUsuarios().Result.Where(x=>x.Login==usuario.Login).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Usuario> AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _contexto.Usuario.Update(usuario);
                await _contexto.SaveChangesAsync();
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task DeletarUsuario(long id)
        {
            try
            {
                var usuario = BuscarTodosUsuarios().Result.Where(x => x.IdUsuario == id).FirstOrDefault();
                _contexto.Usuario.Remove(usuario);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}
