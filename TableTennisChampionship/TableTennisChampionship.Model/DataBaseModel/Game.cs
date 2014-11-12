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
        [Required(ErrorMessage="Няма пореден номер на гейм!")]
        public int GameNumber { get; set; }
        public int PointsWin{get;set;}
        public int PoinsLost{get;set;}
       
        [Display(Name = "Спечелил играч")]
      
        public virtual Player WonPlayer { get; set; }
     
        [Display(Name = "Загубил играч")]
       
        public virtual Player LostPlayer { get; set; }
    }
    
}
