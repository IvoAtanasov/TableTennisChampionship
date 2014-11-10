using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace TableTennisChampionship.Model.DataBaseModel
{
    public class MatchRule
    {
        [Key]
        public int MatchRuleID { get; set; }
        [Display(Name="Точки за гейм")]
        [Required(ErrorMessage="Въведете точки за гейм!")]
        public int PointsPerGame { get; set; }
        [Required(ErrorMessage="Въведете правило за 3 точки")]
        [Display(Name = "Резултат за 3 точки")]
        public string ThreePoints { get; set; }
        [Required(ErrorMessage="Въведете правило за 2 точки")]
        [Display(Name = "Резултат за 2 точки")]
        public string TwoPoints { get; set; }
        [Required(ErrorMessage="Въведете правило за 1 точки")]
        [Display(Name = "Резултат за 1 точки")]
        public string OnePoint { get; set; }
    }
}