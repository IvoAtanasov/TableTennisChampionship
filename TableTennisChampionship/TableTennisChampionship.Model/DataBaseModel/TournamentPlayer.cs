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
        [Required]
        public virtual Tournament Tournament { get; set; }
        [Required]
        public virtual Player Player { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }

    }
}
