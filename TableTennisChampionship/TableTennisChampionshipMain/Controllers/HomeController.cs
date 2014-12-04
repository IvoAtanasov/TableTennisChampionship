namespace TableTennisChampionshipMain.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TableTennisChampionship.Model.DataBaseModel;
    using WorkingWithDataMvc.Data;
    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        private readonly IRepository<Player> player;

       
        public HomeController(IRepository<Player> player) {
            this.player = player;
        }
        public HomeController()
        { 
        
        }

        public ActionResult Index()
        {
            //var matches = this.matches.All();
            ViewBag.UserName = this.CurrentUserName;

            return this.View();
          
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
        [HttpGet]
        public ActionResult RegisterPlayer()
        {
            var playerList = player.All()
            .Project()
            .To<TableTennisChampionshipMain.ViewModels.PlayerInfo>();
            return View(playerList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterPlayer(TableTennisChampionshipMain.ViewModels.PlayerInfo player)
        {
           
            return View();
        }
    }
}