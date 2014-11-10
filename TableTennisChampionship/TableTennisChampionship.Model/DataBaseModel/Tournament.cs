﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisChampionship.Model.DataBaseModel
{
    public class Tournament
    {
        [Key]
        public int TournamentID { get; set; }
        [Required(ErrorMessage = "Не сте задали начална дата на турнира")]
        [Display(Name="Начална дата")]  
        public DateTime StartDate { get; set; }
        [Display(Name="Крайна дата")]
        public DateTime EndDate { get; set; }
      
        public int FirstPlacePlayerID { get;set; }
        public virtual Player FirstPlacePlayer { get; set; }
      
        public int SecondPlacePlayerID { get; set; }
        public virtual Player SecondPlacePlayer { get; set; }
   
        public int ThirdPlacePlayerID { get; set; }
        public virtual Player ThirdPlacePlayer { get; set; }
        [Required]
        public int TournamentTypeID { get; set; }
        public virtual TournamentType TournamentType { get; set; }
        [Required]
        public int AdvanceGroupCriteriaID { get; set; }
        public virtual AdvanceGroupCriteria AdvanceGroupCriteria { get; set; }
    }
}