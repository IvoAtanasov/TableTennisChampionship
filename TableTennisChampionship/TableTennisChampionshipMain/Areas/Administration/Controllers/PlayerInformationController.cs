using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionshipData;
using WorkingWithDataMvc.Data;
using TableTennisChampionshipMain.ViewModels;
using TableTennisChampionship.Model.DataBaseModel;
using AutoMapper.QueryableExtensions;

namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
    public class PlayerInformationController : Controller
    {
        private readonly IRepository<Player> player;

        public PlayerInformationController(IRepository<Player> player) {
            this.player = player;
        }
        // GET: /Administration/PlayerInfo/
        public ActionResult Index()
        {
            var playerList = player.All()
                .Project()
                .To<PlayerInfo>();
            return View(playerList);
        }

        // GET: /Administration/PlayerInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var currentPlayer = player.All().FirstOrDefault(id);
            //if (player == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: /Administration/PlayerInfo/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: /Administration/PlayerInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,FirstName,LastName,PhotoFile,Age")] TableTennisChampionshipMain.ViewModels.PlayerInfo player)
        {
            if (ModelState.IsValid)
            {
                this.player.Add(new Player { 
                PlayerID=player.PlayerID,
                FirstName=player.FirstName,
                LastName=player.LastName,
                PhotoFile=player.PhotoFile,
                Age=player.Age
                });
                this.player.SaveChanges();
                var path =System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"),player.PhotoFile);
                
                return RedirectToAction("Index");
            }
            
            return View(player);
        }

        // GET: /Administration/PlayerInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //if (player == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: /Administration/PlayerInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerID,FirstName,LastName,PhotoFile,Age")] Player player)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(player).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: /Administration/PlayerInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = db.Players.Find(id);
            //if (player == null)
            //{
            //    return HttpNotFound();
            //}
            return View(player);
        }

        // POST: /Administration/PlayerInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Player player = db.Players.Find(id);
            //db.Players.Remove(player);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
