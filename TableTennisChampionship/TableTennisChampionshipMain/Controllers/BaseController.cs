using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionshipData;
using TableTennisChampionshipMain.ViewModels;


namespace TableTennisChampionshipMain.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ApplicationUser CurrentUser { get; set; }
	}
}