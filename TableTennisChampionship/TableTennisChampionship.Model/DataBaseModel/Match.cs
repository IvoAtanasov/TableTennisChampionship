using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisChampionship.Model.DataBaseModel
{
   public  class Match
    {
        [Key]   
        public int MatchID {get;set;}
        [Required]
        [Display(Name="Maч")]
        [MaxLength(150)]
        public string MatchName { get; set; }
        public int PLayerWonPoints { get; set; }
        public int PlayerLostPoints { get; set; }
     
        [Display(Name = "Спечелил играч")]
     
        public int WonPlayerID { get; set; }
        public virtual Player WonPlayer { get; set; }
   
        [Display(Name = "Загубил играч")]
        
        public virtual Player LostPlayer { get; set; }
      
        public virtual Tournament Tournament { get; set; }

        public virtual Stage Stage { get; set; }


    }
}
