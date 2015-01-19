namespace TableTennisChampionshipMain.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    public class TournamentPlayerInfo
    {
        [Required]
        public int PlayerID { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
    }
}