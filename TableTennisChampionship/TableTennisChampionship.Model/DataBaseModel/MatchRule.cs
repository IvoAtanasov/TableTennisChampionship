using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace TableTennisChampionship.Models
{
    public class MatchRule
    {
        [Key]
        public int MatchRuleID { get; set; }
        [Display(Name="Точки за гейм")]
        public int PointsPerGame { get; set; }
    }
}