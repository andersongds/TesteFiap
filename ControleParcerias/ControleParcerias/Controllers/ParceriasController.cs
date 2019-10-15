using ControleParcerias.Mappers;
using ControleParcerias.Models;
using ControleParceriasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControleParcerias.Controllers
{
    public class ParceriasController : Controller
    {
        // GET: Parcerias
        public ActionResult Index()
        {
            return RedirectToAction("ListarParcerias");
        }

        public ActionResult CadastroParcerias()
        {
            return View("CadastroParcerias", new ParceriaModelView());
        }
        [HttpPost]
        public async Task<ActionResult> CadastroParcerias(ParceriaModelView parceriaModelView)
        {
            var conta = await AcessaAPI.ObterPorTitulo(parceriaModelView.Titulo);
            if (conta.Count > 0)
                ModelState.AddModelError("Titulo", "Titulo já esta cadastrado");
            if (ModelState.IsValid)
            {
                var parceiroModel = ConverterModelViewToParceiroModel.ConvertModelViewToModel(parceriaModelView);
                parceiroModel.DataHoraCadastro = DateTime.Now;
                var CriacaoParceria = await AcessaAPI.Criar(parceiroModel);
                


                return RedirectToAction("ListarParcerias");
                
            }
            else{
                return View(parceriaModelView);
                }

       }

        public async Task<ActionResult> AtualizarParcerias(int Codigo)
        {
            var parceriamodel = await AcessaAPI.ObterPorCodigo(Codigo);
            return View("AtualizarParcerias", ConverterParceiroModelToModelView.ConvertModelToModelView(parceriamodel));
        }
        [HttpPost]
        public async Task<ActionResult> AtualizarParcerias(ParceriaModelView parceriaModelView)
        {

            
                
            if (ModelState.IsValid)
            {
                var parceiroModel = ConverterModelViewToParceiroModel.ConvertModelViewToModel(parceriaModelView);
                parceiroModel.DataHoraCadastro = DateTime.Now;
                var CriacaoParceria = await AcessaAPI.Atualizar(parceiroModel);



                return RedirectToAction("ListarParcerias");

            }
            else
            {
              
                return View(parceriaModelView);
            }

        }

        public async Task<ActionResult> ListarParcerias()
        {
            var listaParcerias = await AcessaAPI.Listar();

            return View(listaParcerias);
        }

        public async Task<ActionResult> Excluir(int Codigo)
        {
            var ParceriaModel   = await AcessaAPI.ObterPorCodigo(Codigo);

            await AcessaAPI.Excluir(ParceriaModel);

            return RedirectToAction("ListarParcerias");
        }

    }
}