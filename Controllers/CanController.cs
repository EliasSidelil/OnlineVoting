using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class CanController : Controller
    {
        // GET: Can
        public ActionResult Index()
        {
            IEnumerable<tbl_candidates> can = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/api/");
                var responseTask = client.GetAsync("Values");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<tbl_candidates>>();
                    readJob.Wait();
                    can = readJob.Result;
                }
                else
                {
                    can = Enumerable.Empty<tbl_candidates>();
                    ModelState.AddModelError(string.Empty, "Server Error comes here!!!");
                }
            }
            return View(can);
        }
    }
}