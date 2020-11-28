using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.Model
{
    public class Divida
    {
        [Key]
        public long IdDivida { get; set; }
        public Cliente Cliente { get; set; }
        public int VlrDivida { get; set; }
        public DateTime DtaVencimento { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DtaCalculo { get; set; }
        public int QtdDiasJuros { get; set; }
        public double VlrJuros { get; set; }
        public string TipoJuros { get; set; }
        public double VlrTotalDivida { get; set; }
  
    }
}
