using System.Web.Mvc;

namespace TableTennisChampionshipMain.Areas.PlayerInfo
{
    public class PlayerInfoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PlayerInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PlayerInfo_default",
                "PlayerInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}