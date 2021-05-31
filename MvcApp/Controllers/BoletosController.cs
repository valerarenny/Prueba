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
    public class BoletosController : Controller
    {
        // GET: Boletos
        string urlMain = "http://localhost:61087/api/";
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Boletos()
        {
            string url = urlMain + "Boletos";
            List<BoletoVIewModel> boletos = new List<BoletoVIewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var boletosResponse = res.Content.ReadAsStringAsync().Result;

                    boletos = JsonConvert.DeserializeObject<List<BoletoVIewModel>>(boletosResponse);
                }
            }
            return Json(boletos, JsonRequestBehavior.AllowGet);
        }


        // POST: Boletos/Create
        [HttpPost]
        public async Task<ActionResult> Create(BoletoVIewModel boletoRequest)
        {
            Dictionary<string, string> BugData = new Dictionary<string, string>
            {
                { "IdViaje", boletoRequest.IdViaje.ToString()},
                { "IdViajero", boletoRequest.IdViajero.ToString()}                
            };
            string url = urlMain + "boletos";
            var httpClient = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(BugData, Formatting.Indented);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content).ConfigureAwait(false);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BoletosEdit(BoletoVIewModel boletoRequest)
        {
            string url = urlMain + $"boletos/{boletoRequest.IdBoleto}";
            Dictionary<string, string> BugData = new Dictionary<string, string>
            {
                { "IdViaje", boletoRequest.IdViaje.ToString()},
                { "IdViajero", boletoRequest.IdViajero.ToString()}
            };

            var httpClient = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(BugData, Formatting.Indented);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);

            return Json(response);
        }

        // POST: Boletos/Edit
        [HttpPost]
        public async Task<ActionResult> GetBoleto(IdG boletoRequest)
        {
            BoletoVIewModel boletosModel = new BoletoVIewModel();
            string url = urlMain + $"boletos/{boletoRequest.IdGuid}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var boleto = response.Content.ReadAsStringAsync().Result;
            boletosModel = JsonConvert.DeserializeObject<BoletoVIewModel>(boleto);

            return Json(boletosModel);
        }

        // POST: Boletos/Delete/5
        [HttpPost]
        public async Task<ActionResult> BoletosDelete(IdG boletoRequest)
        {
            string url = urlMain + $"boletos/{boletoRequest.IdGuid}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);
            return Json(response);
        }
    }
}