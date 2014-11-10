using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Model.DataBaseModel
{
    public class TournamentType
    {
        [Key]
        public int TournamentTypeID { get; set; }
        [Display(Name="Вид на турнира")]
        public string TournamentTypeName { get; set; }


    }
}