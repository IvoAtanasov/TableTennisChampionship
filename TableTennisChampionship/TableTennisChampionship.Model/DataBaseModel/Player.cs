using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required(ErrorMessage="Името задължително поле")]
        [Display( Name="Име")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилията е задължително поле")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        public string PhotoFile { get; set; }
        [Display(Name="Години")]
        public int? Age { get; set; }

    }
}