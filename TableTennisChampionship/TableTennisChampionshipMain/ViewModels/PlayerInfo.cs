using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TableTennisChampionshipMain.Infrastructure;
using TableTennisChampionship.Model.DataBaseModel;

namespace TableTennisChampionshipMain.ViewModels
{
    public class PlayerInfo:IMapFrom<Player>
    {
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "Името задължително поле")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилията е задължително поле")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Профилна снимка")]
        public string PhotoFile { get; set; }
        [Display(Name="Файл за профилна снимка")]
        public HttpPostedFileBase PostedFile { get; set; }
        [Display(Name = "Години")]
        public int? Age { get; set; }
    }
}