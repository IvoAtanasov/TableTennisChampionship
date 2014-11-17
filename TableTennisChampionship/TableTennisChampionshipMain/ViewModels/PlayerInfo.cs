﻿using System;
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
        [Required(ErrorMessage = "Името задължително поле")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилията е задължително поле")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        public string PhotoFile { get; set; }
        [Display(Name = "Години")]
        public int? Age { get; set; }
    }
}