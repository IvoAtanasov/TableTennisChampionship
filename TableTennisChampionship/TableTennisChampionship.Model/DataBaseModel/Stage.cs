using System;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Model.DataBaseModel
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