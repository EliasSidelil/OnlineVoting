using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class CandiController : Controller
    {
        public static HttpClient WebApiClient = new HttpClient();
        // GET: Candi
        public ActionResult Index()
        {
           // IEnumerable<mvcCandiModel> canList;
            WebApiClient.BaseAddress = new Uri("https://localhost:44332/api/");
           // WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.GetAsync("Candi").Result;
            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mvcCandiModel>>().Result;
           // canList = response.Content.ReadAsAsync<IEnumerable<mvcCandiModel>>().Result;
            //return View(canList);
            return View();
        }
    }
}


