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
        [MaxLength(150)]
        public string TournamentTypeName { get; set; }


    }
}