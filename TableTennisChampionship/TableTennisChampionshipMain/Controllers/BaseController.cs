using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableTennisChampionshipData;
using TableTennisChampionshipMain.ViewModels;
using Microsoft.AspNet.Identity;
using WorkingWithDataMvc.Data;


namespace TableTennisChampionshipMain.Controllers
{
    public abstract class BaseController : Controller
    {
        // private readonly IRepository<ApplicationUser> _user;
        //private string _currentUserId;
        //private ApplicationUser _currentUser;
        //private int? _playerID;

        //public BaseController(IRepository<ApplicationUser> user)
        //{
        //    //this._user = user;
        //    //if (User != null && User.Identity != null)
        //    //{
        //    //    _currentUserId = User.Identity.GetUserId();
        //    //    _currentUser = this._user.All().FirstOrDefault(x => x.Id == _currentUserId);
        //    //    _playerID = this._currentUser.PlayerID;
        //    //}
        //}
        public BaseController()
        {

        }
        //protected ApplicationUser CurrentUser
        //{
        //    get
        //    {
        //        //string currentUserId = User.Identity.GetUserId();
        //        //return this._user.All().FirstOrDefault(x => x.Id == currentUserId);
        //        return _currentUser;
        //    }

        //}
        protected String CurrentUserName
        {
            get
            {
                if (User != null && User.Identity != null)
                {
                    return User.Identity.GetUserName();
                }
                else
                {
                    return "Anonymous";
                }
            }
        }
            //}
            //protected int? User_PlayerID
            //{
            //    get 
            //    {
            //        //string currentUserId = User.Identity.GetUserId();
            //        //return this._user.All().FirstOrDefault(x => x.Id == currentUserId).PlayerID;
            //        return _playerID;
            //    }
            //}        
    }
}