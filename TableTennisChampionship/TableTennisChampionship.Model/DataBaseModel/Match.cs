using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TableTennisChampionship.Models;


namespace TableTennisChampionship.Model.DataBaseModel
{
   public  class Match
    {
        [Key]   
        public int MatchID {get;set;}
        [Required]
        [Display(Name="Maч")]
        public string MatchName { get; set; }
        public int PLayerWonPoints { get; set; }
        public int PlayerLostPoints { get; set; }
        [ForeignKey("FK_PlayerWon")]
        [Display(Name = "Спечелил играч")]
        [Column("PlayerWon")]
        public int WonPlayerID { get; set; }
        public virtual Player WonPlayer { get; set; }
        [ForeignKey("FK_PlayerLost")]
        [Display(Name = "Загубил играч")]
        [Column("PlayerLost")]
        public int LostPlayerID { get; set; }
        public virtual Player LostPlayer { get; set; }

        [ForeignKey("FK_TournamentMatch")]
        public int TournamentID { get; set; }
        public virtual Tournament Tournament { get; set; }

        [ForeignKey("FK_StageTournament")]
        public int StageID { get; set; }
        public virtual Stage Stage { get; set; }


    }
}
