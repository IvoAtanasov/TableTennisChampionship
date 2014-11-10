using System;
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
        [ForeignKey("FK_PlayerTitleWon")]
        public int FirstPlacePlayerID { get;set; }
        public virtual Player FirstPlacePlayer { get; set; }
        [ForeignKey("FK_PlayerSecond")]
        public int SecondPlacePlayerID { get; set; }
        public virtual Player SecondPlacePlayer { get; set; }
        [ForeignKey("FK_PlayerThird")]
        public int ThirdPlacePlayerID { get; set; }
        public virtual Player ThirdPlacePlayer { get; set; }
        [ForeignKey("FK_TypeTournament")]
        public int TournamentTypeID { get; set; }
        public virtual TournamentType Stage { get; set; }
        [ForeignKey("FK_AdvanceCriteriaTournament")]
        public int AdvanceGroupCriteriaID { get; set; }
        public virtual AdvanceGroupCriteria AdvanceGroupCriteria { get; set; }
    }
}