using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.Model
{
    public class Cliente
    {
        [Key]
        public long IdCliente { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
    }
}
