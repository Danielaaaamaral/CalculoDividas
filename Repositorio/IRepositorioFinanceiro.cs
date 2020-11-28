using Financeiro.WebAPI.Model;
using Financeiro.WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.Contexto
{
    interface IRepositorioFinanceiro
    {

        #region Dividas
        Task<List<Divida>> BuscarTodosDividas();
        Task<Divida> BuscarDividaPorId(long Id);
        Task<Divida> AdicionarDivida(Divida divida);
        Task<Divida> AtualizarDivida(Divida divida);

        Task DeletarDivida(long id);
        double CalcularJurosSimples(double valorDivida, int dias, double vlrJuros);
        public double CalcularJurosComposto(double valorDivida, int dias, double vlrJuros);
        double CalcularVlrParcela(double valorDividaJuros, int qtdParcelas);
        int CalcularQtdDiasJuros(DateTime dataVencimento);
        Task<DividaRespostaViewModel> CalcularDivida(DividaViewModel dividaV);
        double CalcularComissao(double valorDividaJuros, double juros);
        #endregion

        #region usuario
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarUsuarioPorId(long Id);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario);
        Task DeletarUsuario(long id);
        #endregion

        #region Cliente
        Task<List<Cliente>> BuscarTodosClientes();
        Task<Cliente> BuscarClientePorId(long Id);
        Task DeletarCliente(long id);
        Task<Cliente> AtualizarCliente(Cliente cliente);
        Task<Cliente> AdicionarCliente(Cliente cliente);
        #endregion
    }
}
