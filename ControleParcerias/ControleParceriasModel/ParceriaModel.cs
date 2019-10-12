using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleParceriasModel
{
    public class ParceriaModel
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public  string Descricao { get; set; }
        public string URLPagina { get; set; }
        public string Empresa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int QtdLikes { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}
