using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
     [Authorize(Roles = "Admin")]
    public class MainController : Controller
    {
        // GET: Administration/Main
        public ActionResult Index()
        {
            return View();
        }
    }
}