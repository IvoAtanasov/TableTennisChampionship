namespace TableTennisChampionshipMain.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using TableTennisChampionship.Model.DataBaseModel;
    using TableTennisChampionshipMain.Infrastructure;

    public class TournamentInfo : IMapFrom<Tournament>, IHaveCustomMappings
    {
        public TournamentInfo()
        {
            this.NewPlayer = new TournamentPlayerInfo();
        }
        public int TournamentID { get; set; }
        [Required(ErrorMessage="Не сте задали наименование на турнира")]
        [Display(Name="Наименование на турнир")]
        public string TournamentName { get; set; }
        [Required(ErrorMessage = "Не сте задали начална дата на турнира")]
        [Display(Name = "Начална дата")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Крайна дата")]
        public DateTime EndDate { get; set; }
        [Display(Name="Вид на турнира")]
        public string TournamentTypeDesc { get; set; }
        [Display(Name="Критерии за продъллжаване в групата")]
        public string AdvanceGroupDesc { get; set; }
        [Required]
        public int TournamentTypeID { get; set; }
        [Required]
        public int AdvanceGroupCriteriaID { get; set; }
        [Display(Name="Победител")]
        public string WinnerFullName { get; set; }
        public ICollection<TournamentPlayer> PlayerList { get; set; }
        public TournamentPlayerInfo NewPlayer { get; set; }
        #region IHaveCustomMappings Members

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            //Mapping advance criteria
            configuration.CreateMap<Tournament, TournamentInfo>()
                .ForMember(m => m.AdvanceGroupDesc, opt => opt.MapFrom(b => b.AdvanceGroupCriteria.AdvanceGroupCriteriaDescription));
            configuration.CreateMap<Tournament, TournamentInfo>()
                .ForMember(m => m.AdvanceGroupCriteriaID, opt => opt.MapFrom(b => b.AdvanceGroupCriteria.AdvanceGroupCriteriaID));
            // Mapping TournamentType
            configuration.CreateMap<Tournament, TournamentInfo>()
                .ForMember(m => m.TournamentTypeDesc, opt => opt.MapFrom(b => b.TournamentType.TournamentTypeName));
            configuration.CreateMap<Tournament, TournamentInfo>()
                .ForMember(m => m.TournamentTypeID, opt => opt.MapFrom(b => b.TournamentType.TournamentTypeID ));

            configuration.CreateMap<Tournament, TournamentInfo>()
               .ForMember(m => m.WinnerFullName, opt => opt.MapFrom(b => b.PlayerList.Where(x => x.Rank == 1).Select(p => p.Player.FirstName +" "+ p.Player.LastName).FirstOrDefault()));


        }

        #endregion
    }
}