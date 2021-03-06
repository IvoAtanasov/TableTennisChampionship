﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionship.Model.DataBaseModel;
using WorkingWithDataMvc.Data;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using System.Net;
using TableTennisChampionshipMain.ViewModels;

namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IRepository<Tournament> tournament;
        private readonly IRepository<AdvanceGroupCriteria> _AdvanceGroupCriteria;
        private readonly IRepository<TournamentType> _TournamenType;
        private readonly IRepository<Player> player;

        //Конструктор,който приема репозитори, подадено му от ninject
        public TournamentController(IRepository<Tournament> tournament, IRepository<AdvanceGroupCriteria> advanceGroupCriteria, IRepository<TournamentType> tournamenType, IRepository<Player> player)
        {
            this.tournament = tournament;
            this._AdvanceGroupCriteria = advanceGroupCriteria;
            this._TournamenType = tournamenType;
            this.player=player;
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
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AdvanceCriteria = AdvanceCriteriaDDL();
            ViewBag.TournamentType = TournamentTypeDDL();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TableTennisChampionshipMain.ViewModels.TournamentInfo trmt)
        {
            Tournament _entityTour =null;
            try
            {
                if (ModelState.IsValid)
                {
                    _entityTour = new Tournament
                    {
                        TournamentName=trmt.TournamentName,
                        AdvanceGroupCriteriaID=trmt.AdvanceGroupCriteriaID,
                        TournamentTypeID=trmt.TournamentTypeID,
                        StartDate=(DateTime)trmt.StartDate,
                        EndDate=(DateTime)trmt.EndDate
                    };
                    this.tournament.Add(_entityTour);
                    this.tournament.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch(Exception ex) 
            { 
            
            }
            return View(trmt);  
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selectTour = this.tournament.All()
                .Where(x => x.TournamentID == id)
                .Project()
                .To<TableTennisChampionshipMain.ViewModels.TournamentInfo>()
                .FirstOrDefault();
            ViewBag.AdvanceCriteria = AdvanceCriteriaDDL();
            ViewBag.TournamentType = TournamentTypeDDL();
            ViewBag.Ranks = RanksDDL();
            if (selectTour == null)
            {
                return HttpNotFound();
            }
            return View(selectTour);
        }
        #region "Private Methods"
        /// <summary>
        /// Връща ViewBag за комбо бокс-продължаване в групата  
        /// </summary>
        /// <returns></returns>
        private SelectList AdvanceCriteriaDDL()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var listAC = (from lst in _AdvanceGroupCriteria.All()
                         select new 
                         { 
                         ID=lst.AdvanceGroupCriteriaID,
                         Name=lst.AdvanceGroupCriteriaDescription
                         }
                         ).ToList();
            result.AddRange(new SelectList( listAC, "ID", "Name"));
            return new SelectList(result, "Value", "Text");
        }
        /// <summary>
        /// Връща ЖиевБаг за комбо бокс- тип на турнира
        /// </summary>
        /// <returns></returns>
        private SelectList TournamentTypeDDL()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var listAC = (from lst in _TournamenType.All()
                          select new
                          {
                              ID = lst.TournamentTypeID,
                              Name = lst.TournamentTypeName
                          }
                         ).ToList();
            result.AddRange(new SelectList(listAC, "ID", "Name"));
            return new SelectList(result, "Value", "Text");
        }
        private SelectList RanksDDL()
        { 
            List<SelectListItem> result = new List<SelectListItem>();
            var rank = (from lst in Enum.GetValues(typeof(RanksEight)).Cast<RanksEight>()
                        select new
                        {
                            ID = (int)lst,
                            Name = lst.ToString()
                        }).ToList();
            result.AddRange(new SelectList(rank, "ID", "Name"));
            return new SelectList( result,"Value","Text");
        }
        #endregion
    }
}