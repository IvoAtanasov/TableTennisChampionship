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
        public int Rank { get; set; }
        public int Points { get; set; }

        #region IHaveCustomMappings Members
        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<TournamentPlayer, TournamentPlayerInfo>()
                .ForMember(m => m.PlayerFullName, opt => opt.MapFrom(x => x.Player.FirstName + " " + x.Player.LastName));
        }
        #endregion
    }
}