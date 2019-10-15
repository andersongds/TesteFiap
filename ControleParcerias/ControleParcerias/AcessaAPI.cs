using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ControleParcerias.Models;
using ControleParceriasModel;
using ControleParcerias.Mappers;
using System.Text;

namespace ControleParcerias
{
    public class AcessaAPI
    {
        public static string UrlApiControleParcerias = System.Configuration.ConfigurationManager.AppSettings["UrlApiControleParcerias"].ToString();
        public static async Task<ParceriaModel> ObterPorCodigo(int Codigo)
        {
            var client = new HttpClient();
            var endpoint = string.Format(UrlApiControleParcerias + "/{0}/{1}?Codigo={2}", "Parceria", "ObterPorCodigo", Codigo);
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
               ParceriaModel parceriaModel = JsonConvert.DeserializeObject<ParceriaModel>(result);
                return parceriaModel; 
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<ParceriaModel>> ObterPorTitulo(string titulo)
        {
            var client = new HttpClient();
            var endpoint = string.Format(UrlApiControleParcerias + "/{0}/{1}?Titulo={2}", "Parceria", "ObterPorTitulo", titulo);
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                List<ParceriaModel> parceriaModel = JsonConvert.DeserializeObject<List<ParceriaModel>>(result);
                return parceriaModel;
            }
            else
            {
                return null;
            }
        }



        public static async Task<List<ParceriaModelView>> Listar()
        {
            var client = new HttpClient();
            var endpoint = string.Format(UrlApiControleParcerias + "/{0}/{1}", "Parceria", "Listar");
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                //return response;
                var result = await response.Content.ReadAsStringAsync();
               List<ParceriaModelView> listaParcerias = JsonConvert.DeserializeObject<List<ParceriaModelView>>(result);
                return listaParcerias; //ConverterParceiroModelToModelView.ConvertModelToModelView(listaParcerias);
            }
            else
            {
                return null;
            }
          
        }
        public static async Task<bool> Criar(ParceriaModel parceriaModel)
        {
            var client = new HttpClient();
            var endpoint = string.Format(UrlApiControleParcerias + "\\{0}\\{1}", "Parceria", "Criar");
            var response = await client.PostAsJsonAsync(endpoint, parceriaModel);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static async Task<bool> Atualizar(ParceriaModel parceriaModel)
        {
            var client = new HttpClient();
            var endpoint = string.Format(UrlApiControleParcerias + "/{0}/{1}", "Parceria", "Atualizar");
            var response = await client.PutAsJsonAsync(endpoint, parceriaModel);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static async Task<bool> Excluir(ParceriaModel parceriaModel)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri(string.Format(UrlApiControleParcerias + "/{0}/{1}", "Parceria", "Excluir")),
                Content = new StringContent(JsonConvert.SerializeObject(parceriaModel), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
    