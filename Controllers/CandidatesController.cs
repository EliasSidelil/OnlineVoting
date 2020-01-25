using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class CandidatesController : Controller
    {
        // GET: Candidates
        public ActionResult Index()
        {
            IEnumerable<CandidatesModels> CandidatesList;
            HttpResponseMessage response = GlobalForApi.CandidatesApiClient.GetAsync("Candidates").Result;
            CandidatesList = response.Content.ReadAsAsync<IEnumerable<CandidatesModels>>().Result;
            return View(CandidatesList);
        }
    }
}