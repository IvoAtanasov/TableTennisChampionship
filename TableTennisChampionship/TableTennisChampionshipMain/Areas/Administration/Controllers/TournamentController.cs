using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionship.Model.DataBaseModel;
using WorkingWithDataMvc.Data;
using System.Data.Entity;

namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IRepository<Tournament> tournament;

        //Конструктор,който приема репозитори, подадено му от ninject
        public TournamentController(IRepository<Tournament> tournament)
        {
            this.tournament = tournament;
        }
        // GET: Administration/Tournament
        public ActionResult Index()
        {
           // var selectedTournament = this.tournament.All().Include(x => x.TournamentType).Include(x => x.FirstPlacePlayer);

            //selectedTournament.First().FirstPlacePlayer.
            return View();
        }
    }
}