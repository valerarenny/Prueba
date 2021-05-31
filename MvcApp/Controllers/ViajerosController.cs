using MvcApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class ViajerosController : Controller
    {
        // GET: Viajeros
        string urlMain = "http://localhost:61087/api/";
   
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Viajeros()
        {
            string url = urlMain + "Viajeros";
            List<ViajeroViewModel> viajeros = new List<ViajeroViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var viajerosResponse = res.Content.ReadAsStringAsync().Result;

                    viajeros = JsonConvert.DeserializeObject<List<ViajeroViewModel>>(viajerosResponse);
                }
            }
            return Json(viajeros, JsonRequestBehavior.AllowGet);
        }


        // POST: Viajeros/Create
        [HttpPost]
        public async Task<ActionResult> Create(ViajeroViewModel viajerosRequest)
        {
            Dictionary<string, string> BugData = new Dictionary<string, string>
            {
                { "nombre", viajerosRequest.nombre },
                { "apellido", viajerosRequest.apellido },
                { "cedula", viajerosRequest.cedula},
                { "telefono", viajerosRequest.telefono },
                { "direccion", viajerosRequest.direccion }                
            };
            string url = urlMain + "viajeros";
            var httpClient = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(BugData, Formatting.Indented);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content).ConfigureAwait(false);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ViajerosEdit(ViajerosEditModel viajerosRequest)
        {
            string url = urlMain + $"viajeros/{viajerosRequest.IdG.IdGuid}";
            Dictionary<string, string> BugData = new Dictionary<string, string>
            {
                { "nombre", viajerosRequest.Viajero.nombre},
                { "apellido", viajerosRequest.Viajero.apellido},
                { "cedula", viajerosRequest.Viajero.cedula},
                { "telefono", viajerosRequest.Viajero.telefono},
                { "direccion", viajerosRequest.Viajero.direccion}
            };

            var httpClient = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(BugData, Formatting.Indented);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);

            return Json(response);
        }

        // POST: Viajeros/Edit
        [HttpPost]
        public async Task<ActionResult> GetViaje(IdG viajerosRequest)
        {
            ViajeroViewModel viajesrosModel = new ViajeroViewModel();
            string url = urlMain + $"viajeros/{viajerosRequest.IdGuid}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var viajeros = response.Content.ReadAsStringAsync().Result;
            viajesrosModel = JsonConvert.DeserializeObject<ViajeroViewModel>(viajeros);

            return Json(viajesrosModel);
        }

        // POST: Viajeros/Delete
        [HttpPost]
        public async Task<ActionResult> ViajerosDelete(IdG viajerosRequest)
        {
            string url = urlMain + $"viajeros/{viajerosRequest.IdGuid}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);
            return Json(response);
        }
    }
}