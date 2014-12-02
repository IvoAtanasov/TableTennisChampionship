
namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
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
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure;

    //[Authorize(Roles = "Admin")]
    public class PlayerInformationController : Controller
    {
        private readonly IRepository<Player> player;
         ///blobClient.GetContainerReference("mycontainer");

        // Create the container if it doesn't already exist.
     //   container.CreateIfNotExists();

        //Конструктор,който приема репозитори, подадено му от ninject
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
            var SelectedPlayer = this.player.All()
                .Where(p => p.PlayerID == id)
                .Project()
                .To<TableTennisChampionshipMain.ViewModels.PlayerInfo>()
                .FirstOrDefault();

            if (SelectedPlayer == null)
            {
                return HttpNotFound();
            }
            return View(SelectedPlayer);
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
        public ActionResult Create([Bind(Include = "PlayerID,FirstName,LastName,PhotoFile,Age,PostedFile")] TableTennisChampionshipMain.ViewModels.PlayerInfo player)
        {
            if (ModelState.IsValid)
            {        
                if (player.PostedFile.ContentLength > 0) 
                {
                    //Запазвам профилната снимкав папка Pictures
                    var fileName = System.IO.Path.GetFileName(player.PostedFile.FileName);
                    #region CommetFileSaveOnContentFolder
                    //var path = System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"), fileName);
                    //var path = System.IO.Path.Combine(Server.MapPath("~/"), fileName);
                    //player.PostedFile.SaveAs(path);
                    #endregion
                    //Запазвам файлът в AzureStorage
                    AzureStorageHelper azureHelper = new AzureStorageHelper();
                    azureHelper.CreateBlob(fileName, player.PostedFile);
                    Player entityPlayer = new Player
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        PhotoFile = fileName,
                        Age = player.Age,
                        ImageUrl=azureHelper.FullBlobUrl(fileName)
                    };
                    //Добавям новото entity и записвам
                    this.player.Add(entityPlayer);
                    this.player.SaveChanges();
                }
                //Връщам към списъка
                return RedirectToAction("Index");
            }
            //При грешка връщам обработения модел
            return View(player);
        }

        // GET: /Administration/PlayerInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var SelectedPlayer = this.player.All()
                .Where(p => p.PlayerID == id)
                .Project()
                .To<TableTennisChampionshipMain.ViewModels.PlayerInfo>()
                .FirstOrDefault();

            if (SelectedPlayer == null)
            {
                return HttpNotFound();
            }
            return View(SelectedPlayer);
        }

        // POST: /Administration/PlayerInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,FirstName,LastName,PhotoFile,Age,PlayerID,ImageUrl")] PlayerInfo player)
        {

            if (ModelState.IsValid)
            {
                if (player.PostedFile.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(player.PostedFile.FileName);
                    AzureStorageHelper azureHelper = new AzureStorageHelper();
                    azureHelper.CreateBlob(fileName, player.PostedFile);
                    player.ImageUrl = azureHelper.FullBlobUrl(fileName);

                }

                Player entityPlayer = new Player
                {
                    PlayerID=player.PlayerID,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    //PhotoFile = player.PhotoFile,
                    Age = player.Age,
                    ImageUrl=player.ImageUrl
                };
                this.player.Update(entityPlayer);
                this.player.SaveChanges();
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
