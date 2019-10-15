using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ControleParceriasModel;
using ControleParceriasBusinness;

namespace ParceriaAPI.Controllers
{
    public class ParceriaEx3Controller : ApiController
    {
        public static ParceriaBusinness _parceriaBusinness = new ParceriaBusinness();
        /// <summary>
        /// obter toda lista de parcerias
        /// </summary>
        /// <returns>List<ParceriaModel></returns>

        //parte 3 inicio 
        [HttpGet]
        public List<ParceriaModel> RetornaLista()
        {
            var ListaParcerias = _parceriaBusinness.RetornaLista().ToList();
            return ListaParcerias;
        }
        [HttpGet]
        public List<ParceriaModel> PesquisaParceria(string pesquisaParam)
        {
            var ListaParcerias = _parceriaBusinness.PesquisaParceria(pesquisaParam).ToList();
            return ListaParcerias;
        }
        [HttpGet]
        public List<ParceriaModel> RetornaParceria(int codigo)
        {
            var ListaParcerias = _parceriaBusinness.RetornaParceria(codigo).ToList();
            return ListaParcerias;
        }

        [HttpPost]
        public IHttpActionResult CadastraLike(int CodigoParceria)
        {
            var ok = _parceriaBusinness.CadastraLike(CodigoParceria);
            return Ok();
        }
        //parte 3 fim
    }
}