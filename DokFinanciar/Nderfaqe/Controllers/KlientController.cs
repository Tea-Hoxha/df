using DokFinanciar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Nderfaqe.Controllers
{
    public class KlientController : Controller
    {
        string Baseurl = "https://localhost:44308/api/Klient";
        public async Task<ActionResult> Index()
        {
            List<Klient> KInfo = new List<Klient>();

            using (HttpClient client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage Res = await client.GetAsync();

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var KResponse = Res.Content.ReadAsStringAsync().Result;
                    KInfo = JsonConvert.DeserializeObject<List<Klient>>(KResponse);

                }
                return View(KInfo);
            }

        }

        /////////////////////////////////////////////////////////////
        /////////////////////////POST////////////////////////////////

        public ActionResult create(Klient klient)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Klient");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Klient>("klient", klient);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index"); 
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(klient);
        }

    }
}