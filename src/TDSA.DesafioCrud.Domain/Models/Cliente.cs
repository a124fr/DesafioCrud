using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDSA.DesafioCrud.Domain.Models
{
    public class Cliente : Entity
    {        
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        
        public Cliente() { }
                
    }
}
