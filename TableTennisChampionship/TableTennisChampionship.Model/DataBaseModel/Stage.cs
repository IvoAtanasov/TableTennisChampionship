using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Models
{
    public class Stage
    {   
        [Key]
        public int StageID { get; set; }
        [Required(ErrorMessage="Име на етап е задължително")]
        [Display(Name="Етап")]
        public string StateName { get; set; }
    }
}