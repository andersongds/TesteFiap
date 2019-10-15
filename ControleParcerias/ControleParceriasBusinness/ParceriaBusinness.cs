using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleParceriasData;
using ControleParceriasModel;
using Dapper;

namespace ControleParceriasBusinness
{
   public class ParceriaBusinness
    {

        // PARTE 3 inicio
        public IEnumerable<ParceriaModel> RetornaLista()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");
            
            sb.Append("  Titulo ");
            sb.Append(" , ISNULL(URLPagina,'') URLPagina ");
            sb.Append(" , Empresa ");           
            sb.Append(" , DataTermino ");
            sb.Append(" , QtdLikes ");
            sb.Append(" FROM dbo.vParceria ");
            sb.Append(" WHERE GETDATE() BETWEEN DataInicio AND DataTermino ");

            return DapperDataAccess.ExecuteCommandReturnList<ParceriaModel>(sb.ToString());

        }
        //PARTE 3
        public IEnumerable<ParceriaModel> PesquisaParceria(string pesquisaParam)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");

            sb.Append("  Titulo ");
            sb.Append(" , ISNULL(URLPagina,'') URLPagina ");
            sb.Append(" , Empresa ");
            sb.Append(" , DataTermino ");
            sb.Append(" , QtdLikes ");
            sb.Append(" FROM dbo.vParceria ");
            sb.Append(" WHERE GETDATE() BETWEEN DataInicio AND DataTermino ");
            sb.Append(" AND titulo LIKE '%" + pesquisaParam + "%'");
            sb.Append(" OR Empresa LIKE '%" + pesquisaParam + "%'");
            return DapperDataAccess.ExecuteCommandReturnList<ParceriaModel>(sb.ToString());

        }
        //PARTE 3

        public IEnumerable<ParceriaModel> RetornaParceria(int? Codigo)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");
            
            sb.Append("  Titulo ");
            sb.Append(" , Descricao ");
            sb.Append(" , ISNULL(URLPagina,'') URLPagina ");
            sb.Append(" , Empresa ");            
            sb.Append(" , DataTermino ");           
            sb.Append(" FROM dbo.vParceria ");
            sb.Append(" WHERE GETDATE() BETWEEN DataInicio AND DataTermino ");
            if (Codigo != null)
                sb.Append(" AND Codigo = " + Codigo);

            return DapperDataAccess.ExecuteCommandReturnList<ParceriaModel>(sb.ToString());

        }

        public bool CadastraLike(int Codigo)
        {
            var parceria = RetornaParceria(Codigo);
            if (parceria.Count() > 0)
            {
                var dbArgs = new DynamicParameters(Codigo);
                dbArgs.Add("Operacao", Operacao.Insert);
                DapperDataAccess.ExecuteWhitoutReturn("spParceria", dbArgs);
                return true;
            }
            return false;
        }

        //PARTE 3 FIM     

        public IEnumerable<ParceriaModel>Obter(int? Codigo)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT "); 
            sb.Append(" Codigo "); 
            sb.Append(" , Titulo ");
            sb.Append(" , Descricao ");
            sb.Append(" , URLPagina ");
            sb.Append(" , Empresa ");
            sb.Append(" , DataInicio ");
            sb.Append(" , DataTermino ");
            sb.Append(" , QtdLikes ");
            sb.Append(" , DataHoraCadastro ");
            sb.Append(" FROM dbo.vParceria ");

            if (Codigo != null)
                sb.Append(" WHERE Codigo = " + Codigo);

            return DapperDataAccess.ExecuteCommandReturnList<ParceriaModel>(sb.ToString());
            
        }

        public IEnumerable<ParceriaModel> ObterPorTitulo(string tilulo)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");
            sb.Append(" Codigo ");
            sb.Append(" , Titulo ");
            sb.Append(" , Descricao ");
            sb.Append(" , URLPagina ");
            sb.Append(" , Empresa ");
            sb.Append(" , DataInicio ");
            sb.Append(" , DataTermino ");
            sb.Append(" , QtdLikes ");
            sb.Append(" , DataHoraCadastro ");
            sb.Append(" FROM dbo.vParceria ");

            if (!string.IsNullOrEmpty(tilulo))
                sb.Append(" WHERE titulo = '" + tilulo + "' ");

            return DapperDataAccess.ExecuteCommandReturnList<ParceriaModel>(sb.ToString());

        }





        public void Criar(ParceriaModel parceriaModel)
        {
            try
            {
                if (parceriaModel == null)
                {
                    throw new Exception("Sem dados de parceria");
                }
                else
                {
                    
                    var dbArgs = new DynamicParameters(parceriaModel);
                    dbArgs.Add("Operacao", Operacao.Insert);
                    DapperDataAccess.ExecuteWhitoutReturn("spParceria", dbArgs );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Atualizar(ParceriaModel parceriaModel)
        {
            try
            {
                if ((parceriaModel == null)||
                   ( parceriaModel.Codigo == 0))
                {
                    throw new Exception("Não há dados para Atualização da Parceria");
                }
                else
                {

                    var dbArgs = new DynamicParameters(parceriaModel);
                    dbArgs.Add("Operacao", Operacao.Update);
                    DapperDataAccess.ExecuteWhitoutReturn("spParceria", dbArgs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(ParceriaModel parceriaModel)
        {
            try
            {
                if ((parceriaModel == null) ||
                   (parceriaModel.Codigo == 0))
                {
                    throw new Exception("Não há dados de parceria para realizar a exclusão");
                }
                else
                {

                    var dbArgs = new DynamicParameters(parceriaModel);
                    dbArgs.Add("Operacao", Operacao.Delete);
                    DapperDataAccess.ExecuteWhitoutReturn("spParceria", dbArgs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
