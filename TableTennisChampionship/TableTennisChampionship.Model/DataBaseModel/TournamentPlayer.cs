namespace TableTennisChampionship.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

     public class TournamentPlayer
    {
        [Key]
        public int TournamentPlayerID { get; set; }

        public int TournamentID { get; set; }
        [ForeignKey("TournamentID")]
        public virtual Tournament Tournament { get; set; }
        public int PlayerID { get; set; }
        [ForeignKey("PlayerID")]
        public virtual Player Player { get; set; }
        public int Rank { get; set; }
        public int PointsForGames { get; set; }
        public int PointsForTournaments { get; set; }

    }
}
