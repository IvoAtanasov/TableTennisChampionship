using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TableTennisChampionship.Model.DataBaseModel;

namespace TableTennisChampionshipMain.ViewModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public virtual IDbSet<Tournament> Tournament { get; set; }
        public virtual IDbSet<TournamentType> TournamentType { get; set; }
        public virtual IDbSet<Stage> Stage { get; set; }
        public virtual IDbSet<Player> Player { get; set; }
        public virtual IDbSet<MatchRule> MatchRule { get; set; }
        public virtual IDbSet<Match> Match { get; set; }
        public virtual IDbSet<Game> Game { get; set; }
        public virtual IDbSet<AdvanceGroupCriteria> AdvanceGroupCriteria { get; set; }
    }
}