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
        public static List<ParceriaModelView> ConvertListaModelToModelView(List<ParceriaModel> listaParcerias)
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


        public static ParceriaModelView ConvertModelToModelView(ParceriaModel parceriasModel)
        {
            ParceriaModelView parceriaModelView = new ParceriaModelView()
                {
                    Codigo = parceriasModel.Codigo,
                    Titulo = parceriasModel.Titulo,
                    Descricao = parceriasModel.Descricao,
                    URLPagina = parceriasModel.URLPagina,
                    Empresa = parceriasModel.Empresa,
                    QtdLikes = parceriasModel.QtdLikes,
                    DataInicio = parceriasModel.DataInicio,
                    DataTermino = parceriasModel.DataTermino,
                    DataHoraCadastro = parceriasModel.DataHoraCadastro
                };
            

            return parceriaModelView;
        }













    }
}