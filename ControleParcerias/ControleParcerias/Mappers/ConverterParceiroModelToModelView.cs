using ControleParcerias.Models;
using ControleParceriasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleParcerias.Mappers
{
    public class ConverterParceiroModelToModelView
    {
        public static List<ParceriaModelView> ConvertModelToModelView(List<ParceriaModel> listaParcerias)
        {
            List<ParceriaModelView> listaParceriaModelView = new List<ParceriaModelView>();
            foreach (var parceria in listaParcerias)
            {
                listaParceriaModelView.Add(new ParceriaModelView()
                {
                    Codigo = parceria.Codigo,
                    Titulo = parceria.Titulo,
                    Descricao = parceria.Descricao,
                    URLPagina = parceria.URLPagina,
                    Empresa = parceria.Empresa,
                    QtdLikes = parceria.QtdLikes,
                    DataInicio = parceria.DataInicio,
                    DataTermino = parceria.DataTermino,
                    DataHoraCadastro = parceria.DataHoraCadastro
                });
            }

            return listaParceriaModelView;
        }
    }
}