using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisChampionship.Model.DataBaseModel
{
  public   class Game
    {
        [Key]
        public int GameID { get; set; }
        public int GameNumber { get; set; }
        public int PointsWin{get;set;}
        public int PoinsLost{get;set;}
          [ForeignKey("FK_PlayerGameWon")]
        [Display(Name = "Спечелил играч")]
        [Column("PlayerWon")]
        public int WonPlayerID { get; set; }
        public virtual Player WonPlayer { get; set; }
        [ForeignKey("FK_PlayerGamelost")]
        [Display(Name = "Загубил играч")]
        [Column("Playerlost")]
        public int LostPlayerID { get; set; }
        public virtual Player LostPlayer { get; set; }
    }
    
}
