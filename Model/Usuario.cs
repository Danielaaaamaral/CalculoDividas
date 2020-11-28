using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.WebAPI.Model
{
    public class Usuario
    {
        [Key]
        public long IdUsuario { get; set; }
        public string Login { get; set; }
        public string senha { get; set; }
        public Cliente Cliente { get; set; }

    }
}
