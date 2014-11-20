using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TableTennisChampionship.Model.DataBaseModel;


namespace TableTennisChampionshipMain.ViewModels
{
    public class TournamentInfo
    {
       
        [Required(ErrorMessage = "Не сте задали начална дата на турнира")]
        [Display(Name = "Начална дата")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Крайна дата")]
        public DateTime EndDate { get; set; }
        public  PlayerInfo FirstPlacePlayer { get; set; }
        public  PlayerInfo SecondPlacePlayer { get; set; }
        public PlayerInfo ThirdPlacePlayer { get; set; }
        //public string TournamentType
        //[Required]    
        //public  TournamentType TournamentType { get; set; }
        //[Required] 
        //public  AdvanceGroupCriteria AdvanceGroupCriteria { get; set; }
        //public List<Match> TournamentMatches{get;set;}
    }
}