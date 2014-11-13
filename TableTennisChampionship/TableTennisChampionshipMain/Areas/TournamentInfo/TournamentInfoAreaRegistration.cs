using System.Web.Mvc;

namespace TableTennisChampionshipMain.Areas.TournamentInfo
{
    public class TournamentInfoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TournamentInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TournamentInfo_default",
                "TournamentInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}