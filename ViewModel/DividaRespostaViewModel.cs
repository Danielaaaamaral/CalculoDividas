using Financeiro.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.ViewModel
{
    public class DividaRespostaViewModel
    {
        public int VlrDivida { get; set; }
        public DateTime DtaVencimento { get; set; }
        public int QtdParcelas { get; set; }
        public int QtdDiasJuros { get; set; }
        public double VlrTotalDivida { get; set; }
        public double VlrParcela { get; set; }
        public int TelContato { get; set; }
    
    }
}
