using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableTennisChampionship.Model.DataBaseModel
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required(ErrorMessage="Името задължително поле")]
        [Display( Name="Име")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилията е задължително поле")]
        [Display(Name = "Фамилия")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string NickName { get; set; }
        [Display(Name="Профилна снимка")]
        public string PhotoFile { get; set; }
        [Display(Name="Години")]
        public int? Age { get; set; }
        public string ImageUrl { get; set; }
    }
}