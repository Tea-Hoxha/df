using DokFinanciar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Nderfaqe.Controllers
{
    public class FurnitorController : Controller
    {
        // GET: Furnitor
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:44308/";

            List<Furnitor> KInfo = new List<Furnitor>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Furnitor");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var KResponse = Res.Content.ReadAsStringAsync().Result;
                    KInfo = JsonConvert.DeserializeObject<List<Furnitor>>(KResponse);

                }
                return View(KInfo);
            }
        }

        // GET: Furnitor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Furnitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Furnitor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Furnitor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Furnitor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Furnitor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Furnitor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
