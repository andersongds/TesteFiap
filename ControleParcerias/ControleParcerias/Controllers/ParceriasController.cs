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
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Form(ParceriaModel parceriaModel)
        {
            var CriacaoParceria = await AcessaAPI.Criar(parceriaModel);

            if (CriacaoParceria)
            {
                var listaParcerias = await AcessaAPI.Listar();
                
            }

            return View("Erro");


        }

    }
}