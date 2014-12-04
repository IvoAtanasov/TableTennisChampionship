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
        private readonly IRepository<ApplicationUser> user;
        public BaseController() 
        {
            //ViewBag.UserName = CurrentUserName;
        }
        protected ApplicationUser CurrentUser
        {
            get;
            set;
        }
        protected String CurrentUserName 
        {
            get 
            {
                if (User.Identity != null)
                {
                    return User.Identity.GetUserName();
                }
                else 
                {
                    return "Anonymous";
                }
            }

        }

        //protected int CurrentUserPlayer
        //{
        //    //get 
        //    //{ 
               
        //    //}
        //}

	}
}