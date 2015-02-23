namespace TableTennisChampionshipMain.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TableTennisChampionshipMain.Infrastructure;
    using TableTennisChampionship.Model.DataBaseModel;
    using System.ComponentModel.DataAnnotations;
    public class TournamentPlayerInfo : IMapFrom<TournamentPlayer> ,IHaveCustomMappings
    {
        
        public int TournamentPlayerID { get; set; }
        [Required]
        public int TournamentID { get; set; }
        [Required]
        public int  PlayerID { get; set; }
        public string PlayerFullName { get; set; }
        [Display(Name="Място")]
        public int Rank { get; set; }
        [Display(Name="Точки от мачове")]
        public int PointsForGames { get; set; }
        [Display(Name="Точки от турнири")]
        public int PointsForTournaments { get; set; }

        #region IHaveCustomMappings Members
        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<TournamentPlayer, TournamentPlayerInfo>()
                .ForMember(m => m.PlayerFullName, opt => opt.MapFrom(x => x.Player.FirstName + " " + x.Player.LastName));
        }
        #endregion
    }
}