﻿namespace TableTennisChampionshipMain.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TableTennisChampionship.Model.DataBaseModel;
    using WorkingWithDataMvc.Data;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TableTennisChampionshipData;
    using Microsoft.AspNet.Identity;
    using ViewModels;
    public class HomeController : BaseController
    {
        private readonly IRepository<Player> player;
        private readonly IRepository<ApplicationUser> _user;
    //    private ApplicationDbContext db = new ApplicationDbContext();
        public HomeController(IRepository<Player> player, IRepository<ApplicationUser> user)
        {
            this.player = player;
            this._user = user;
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
            SelectedPlayerInfo spi = new SelectedPlayerInfo
            {
                PlayerList=playerList
            };
            return View(spi);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterPlayer(TableTennisChampionshipMain.ViewModels.SelectedPlayerInfo spi)
        {
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = this._user.All().FirstOrDefault(x => x.Id == currentUserId);//db.Users.FirstOrDefault(x => x.Id == currentUserId);
            //var entityPlayer = player.All()
            //    .Where(p => p.PlayerID == spi.SelectedPlayerID)
            //    .FirstOrDefault();
            //    //.Project()
            //    //.To<TableTennisChampionshipMain.ViewModels.PlayerInfo>();
            //  currentUser.Player = entityPlayer;
            //  _user.Update(currentUser);
            //  _user.SaveChanges();
            return View();
        }
    }
}