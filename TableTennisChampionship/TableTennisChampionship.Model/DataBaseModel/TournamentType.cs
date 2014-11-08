
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Models
{
    public class TournamentType
    {
        [Key]
        public int TournamentTypeID { get; set; }
        [Display(Name="Вид на турнира")]
        public string TournamentTypeName { get; set; }
    }
}