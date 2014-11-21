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

namespace TableTennisChampionshipMain.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlayerInformationController : Controller
    {
        private readonly IRepository<Player> player;
      // private CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

      //  // Create the blob client.
      // private CloudBlobClient blobClient; //storageAccount.CreateCloudBlobClient();

      //  // Retrieve a reference to a container. 
      //private  CloudBlobContainer container ; ///blobClient.GetContainerReference("mycontainer");

        // Create the container if it doesn't already exist.
     //   container.CreateIfNotExists();

        //Конструктор,който приема репозитори, подадено му от ninject
        public PlayerInformationController(IRepository<Player> player) {
            //this.player = player;
            //this.blobClient = this.storageAccount.CreateCloudBlobClient();
            //this.container = this.blobClient.GetContainerReference("ProfilePictures");
            //container.CreateIfNotExists();
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
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Pictures/"), fileName);
                    //var path = System.IO.Path.Combine(Server.MapPath("~/"), fileName);
                    player.PostedFile.SaveAs(path);
                    //Връзвам Viewmodel към entitymodel

                    //CloudBlockBlob blockBlob = this.container.GetBlockBlobReference(fileName);
                    //System.IO.Stream pictureStream=System.IO.Stream.Null ;
                    //player.PostedFile.InputStream.CopyTo(pictureStream);

                    //using (pictureStream  )
                    //{
                    //    blockBlob.UploadFromStream(pictureStream );

                    //}
                    Player entityPlayer = new Player
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        PhotoFile = fileName,
                        Age = player.Age
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
        public ActionResult Edit([Bind(Include = "PlayerID,FirstName,LastName,PhotoFile,Age,PlayerID")] PlayerInfo player)
        {
            if (ModelState.IsValid)
            {
                Player entityPlayer = new Player
                {
                    PlayerID=player.PlayerID,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    PhotoFile = player.PhotoFile,
                    Age = player.Age
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
