﻿using System;
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
                        AdvanceGroupCriteria = _AdvanceGroupCriteria.All().FirstOrDefault(x=>x.AdvanceGroupCriteriaID==trmt.AdvanceGroupCriteriaID),
                        TournamentType=_TournamenType.All().FirstOrDefault(x=>x.TournamentTypeID==trmt.TournamentTypeID),
                        StartDate=trmt.StartDate,
                        EndDate=trmt.EndDate
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
        #region "Private Methods"
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
        #endregion
    }
}