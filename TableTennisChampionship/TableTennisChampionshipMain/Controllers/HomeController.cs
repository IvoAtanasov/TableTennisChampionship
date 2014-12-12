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
            IEnumerable<PlayerInfo> playerList = null;
            int? selectedPlayerID = null;
            if (User != null && User.Identity != null)
            {

                string currentUserId = User.Identity.GetUserId();
                selectedPlayerID = this._user.All().FirstOrDefault(x => x.Id == currentUserId).PlayerID;//селектирам играча за текущия потребител  
                if (selectedPlayerID != null)
                {
                    playerList = player.All()
                    .Where(x => x.PlayerID == selectedPlayerID)
                   .Project()
                   .To<TableTennisChampionshipMain.ViewModels.PlayerInfo>();
                }
                else
                {
                    playerList = player.All()
                    .Project()
                    .To<TableTennisChampionshipMain.ViewModels.PlayerInfo>();
                }

            }
            else
            {
                throw new Exception();
            }
            SelectedPlayerInfo spi = new SelectedPlayerInfo
            {
                PlayerList = playerList,
                SelectedPlayerID = selectedPlayerID
            };

            return View(spi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterPlayer(TableTennisChampionshipMain.ViewModels.SelectedPlayerInfo spi)
        {
            int? selectPlayerId = spi.SelectedPlayerID;
            PlayerInfo playerInfo = null;
            try
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = this._user.All().FirstOrDefault(x => x.Id == currentUserId);
                currentUser.PlayerID = spi.SelectedPlayerID;
                _user.Update(currentUser);
                _user.SaveChanges();
                playerInfo = player.All()
                    .Where(p => p.PlayerID == selectPlayerId)
                    .Project()
                    .To<PlayerInfo>()
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            spi.PlayerList = new List<PlayerInfo>() { playerInfo };
            return View(spi);
        }
    }
}