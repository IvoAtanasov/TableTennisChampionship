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
        [Display(Name = "Резултат за 3 точки")]
        public string ThreePoints { get; set; }
        [Display(Name = "Резултат за 2 точки")]
        public string TwoPoints { get; set; }
        [Display(Name = "Резултат за 1 точки")]
        public string OnePoint { get; set; }
    }
}