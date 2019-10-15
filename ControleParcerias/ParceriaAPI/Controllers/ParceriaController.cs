using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ControleParceriasModel;
using ControleParceriasBusinness;

namespace ParceriaAPI.Controllers
{
    public class ParceriaController : ApiController
    {
        public static ParceriaBusinness _parceriaBusinness = new ParceriaBusinness();
        /// <summary>
        /// obter toda lista de parcerias
        /// </summary>
        /// <returns>List<ParceriaModel></returns>
        [HttpGet]
        public List<ParceriaModel>Listar()
        {
            var ListaParcerias = _parceriaBusinness.Obter(null).ToList();
            return ListaParcerias;
        }

        [HttpGet]
        public ParceriaModel ObterPorCodigo(int Codigo)
        {
            var ListaParcerias = _parceriaBusinness.Obter(Codigo).ToList();
            return ListaParcerias.First();
        }

        [HttpGet]
        public List<ParceriaModel> ObterPorTitulo( string titulo)
        {
            var ListaParcerias = _parceriaBusinness.ObterPorTitulo(titulo).ToList();
            return ListaParcerias;
        }

        /// <summary>
        /// Inserir uma parceria no sistema
        /// </summary>
        /// <returns>true|Parceiro criado - false|Erro na criacao</returns>
        [HttpPost]
        public IHttpActionResult Criar(ParceriaModel parceriaModel)
        {
            try
            {
                _parceriaBusinness.Criar(parceriaModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Atualizar dados de parceria
        /// </summary>
        /// <param name="parceriaModel"></param>
        /// <returns>true|Parceiro Atualizado - false|Erro na Atualização</returns>
        [HttpPut]
        public IHttpActionResult Atualizar(ParceriaModel parceriaModel)
        {
            try
            {
                _parceriaBusinness.Atualizar(parceriaModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Excluir dados de parceria
        /// </summary>
        /// <param name="parceriaModel"></param>
        /// <returns>true|Parceiro Excluído - false|Erro na Exclusão</returns>
        [HttpDelete]
        public IHttpActionResult Excluir(ParceriaModel parceriaModel)
        {
            try
            {
                _parceriaBusinness.Excluir(parceriaModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}