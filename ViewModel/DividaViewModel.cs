using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.ViewModel
{
    public class DividaViewModel
    {
        public int IdCliente { get; set; }
        public int IdDivida { get; set; }
        public string TipoJuros { get; set; }
        public double vlrJuros { get; set; }
        public int QtdParcelas { get; set; }
        public double Comissao { get; set; }
    }
}
