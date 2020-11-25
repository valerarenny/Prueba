using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EtechWebMVC.Models;
using Newtonsoft.Json;

namespace EtechWebMVC.Controllers
{
    public class HomeController : Controller
    {
        string urlMain = "http://localhost:61087/api/"; 
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public async Task<ActionResult> Viajes()
        {
            string url = urlMain + "Viajes";
            List<ViajesViewModel> viajes = new List<ViajesViewModel>();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var viajesResponse = res.Content.ReadAsStringAsync().Result;

                    viajes = JsonConvert.DeserializeObject<List<ViajesViewModel>>(viajesResponse);
                }
            }
            return Json(viajes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Viajes(ViajesViewModel viajeRequest)
        {
            Dictionary<string, string> BugData = new Dictionary<string, string>
            {
                { "nplazas", viajeRequest.nplazas },
                { "destino", viajeRequest.destino },
                { "origen", viajeRequest.origen },
                { "precio", viajeRequest.precio.ToString() }              
            };
            string url = urlMain + "Viajes";
            var httpClient = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(BugData, Formatting.Indented);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content).ConfigureAwait(false);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ViajesDelete(IdG viajeRequest)
        {
            string url = urlMain + $"Viajes/{viajeRequest.IdGuid}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ViajesEdit(ViajesEditModel viajeRequest)
        {
            string url = urlMain + $"viajes/{viajeRequest.IdG.IdGuid}";
            Dictionary<string, string> BugData = new Dictionary<string, string>
            {
                { "nplazas", viajeRequest.Viaje.nplazas },
                { "destino", viajeRequest.Viaje.destino },
                { "origen", viajeRequest.Viaje.origen },
                { "precio", viajeRequest.Viaje.precio.ToString() }
            };
            
            var httpClient = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(BugData, Formatting.Indented);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");      
            var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> GetViaje(IdG viajeRequest)
        {
            ViajesViewModel viajesModel = new ViajesViewModel();
            string url = urlMain + $"viajes/{viajeRequest.IdGuid}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var viaje = response.Content.ReadAsStringAsync().Result;
            viajesModel = JsonConvert.DeserializeObject<ViajesViewModel>(viaje);

            return Json(viajesModel);
        }



    }
}