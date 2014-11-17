using System.Web.Mvc;

namespace TableTennisChampionshipMain.Areas.PlayerInfoStat
{
    public class PlayerInfoStatAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PlayerInfoStat";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PlayerInfoStat_default",
                "PlayerInfoStat/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}