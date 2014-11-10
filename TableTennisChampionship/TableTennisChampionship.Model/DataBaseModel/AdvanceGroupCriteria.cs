﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Model.DataBaseModel
{
    class AdvanceGroupCriteria
    {
        [Key]
        public int AdvanceGroupCriteriaID { get; set; }
        [Required]
        public string AdvanceGroupCriteriaDescription { get; set; }
    }
}
