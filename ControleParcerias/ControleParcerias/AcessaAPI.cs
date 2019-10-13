using ControleParceriasModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ControleParcerias
{
    public class AcessaAPI
    {
        public static string UrlApiControleParcerias = System.Configuration.ConfigurationManager.AppSettings["UrlApiControleParcerias"].ToString();



        public static async Task<ParceriaModel> Listar()
        {
            var client = new HttpClient();
            var endpoint = string.Format(UrlApiControleParcerias + "\\{0}\\{1}", "Parceria", "Listar");
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                //return response;
                var result = await response.Content.ReadAsStringAsync();
                List<ParceriaModel> listaParcerias = JsonConvert.DeserializeObject<List<ParceriaModel>>(result);
            }
            else
            {
                return null;
            }
            return null;
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
    }
}
    