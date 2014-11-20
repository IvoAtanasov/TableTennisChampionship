using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Model.DataBaseModel
{
    public class AdvanceGroupCriteria
    {
        [Key]
        public int AdvanceGroupCriteriaID { get; set; }
        [Required]
        [MaxLength(255)]
        public string AdvanceGroupCriteriaDescription { get; set; }
    }
}
