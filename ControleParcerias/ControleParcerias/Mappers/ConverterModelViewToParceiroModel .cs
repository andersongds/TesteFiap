using ControleParcerias.Models;
using ControleParceriasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleParcerias.Mappers
{
    public class ConverterModelViewToParceiroModel
    {
        public static List<ParceriaModel> ConvertListaModelViewToModel(List<ParceriaModelView> listaParcerias)
        {
            List<ParceriaModel> listaParceriaModel = new List<ParceriaModel>();
            foreach (var parceria in listaParcerias)
            {
                listaParceriaModel.Add(new ParceriaModel()
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

            return listaParceriaModel;
        }
        public static ParceriaModel ConvertModelViewToModel(ParceriaModelView ParceriaView)
        {
            ParceriaModel ParceriaModel = new ParceriaModel();

            ParceriaModel = new ParceriaModel()
                {
                    Codigo = ParceriaView.Codigo,
                    Titulo = ParceriaView.Titulo,
                    Descricao = ParceriaView.Descricao,
                    URLPagina = ParceriaView.URLPagina,
                    Empresa = ParceriaView.Empresa,
                    QtdLikes = ParceriaView.QtdLikes,
                    DataInicio = ParceriaView.DataInicio,
                    DataTermino = ParceriaView.DataTermino,
                    DataHoraCadastro = ParceriaView.DataHoraCadastro
                };
            

            return ParceriaModel;
        }







    }
}