using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Models
{
    public class AdvanseGroupCriteria
    {
        [Key]
        public int AdvanceGroupCriteriaID { get; set; }
        [Display(Name="Критерий за продължаване в групата")]
        public string AdvanceGroupCriteriaDescription { get; set; }
    }
}