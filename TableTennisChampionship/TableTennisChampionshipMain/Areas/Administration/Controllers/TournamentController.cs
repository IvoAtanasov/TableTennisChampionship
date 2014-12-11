using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionship.Model.DataBaseModel;
using WorkingWithDataMvc.Data;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;

namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IRepository<Tournament> tournament;
        private readonly IRepository<AdvanceGroupCriteria> _AdvanceGroupCriteria;
        private readonly IRepository<TournamentType> _TournamenType;

        //Конструктор,който приема репозитори, подадено му от ninject
        public TournamentController(IRepository<Tournament> tournament, IRepository<AdvanceGroupCriteria> advanceGroupCriteria, IRepository<TournamentType> tournamenType)
        {
            this.tournament = tournament;
            this._AdvanceGroupCriteria = advanceGroupCriteria;
            this._TournamenType = tournamenType;
        }
        // GET: Administration/Tournament
        public ActionResult Index()
        {
            var tournamentList = this.tournament.All()
                .Include(x => x.TournamentType)
                .Include(x => x.AdvanceGroupCriteria)
                .Include("TournamentPlayers")
                .Project()
                .To<TableTennisChampionshipMain.ViewModels.TournamentInfo>();

            //selectedTournament.First().FirstPlacePlayer.
            return View(tournamentList);
        }
        #region "Private Methods"
        private SelectList AdvanceCriteria()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            return new SelectList(result, "Value", "Text");
        }
        #endregion
    }
}