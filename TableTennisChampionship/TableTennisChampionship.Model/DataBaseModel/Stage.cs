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
        [MaxLength(50)]
        public string StateName { get; set; }
    }
}