using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionship.Model.DataBaseModel;
using WorkingWithDataMvc.Data;

namespace TableTennisChampionshipMain.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<Match> matches;

        public HomeController(IRepository<Match> matches)
        {
            this.matches = matches;
        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            var matches = this.matches.All();

            return this.View(matches);
          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}