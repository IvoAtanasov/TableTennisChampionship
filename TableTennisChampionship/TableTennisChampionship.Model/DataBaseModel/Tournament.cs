namespace TableTennisChampionship.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Tournament
    {
        [Key]
        public int TournamentID { get; set; }
        [StringLength(200)]
        public string TournamentName { get; set; }
        [Required(ErrorMessage = "Не сте задали начална дата на турнира")]
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }
        [Required]
        public virtual TournamentType TournamentType { get; set; }
        [Required]
        public virtual AdvanceGroupCriteria AdvanceGroupCriteria { get; set; }
        public virtual ICollection<TournamentPlayer> PlayerList { get; set; }
    }
}