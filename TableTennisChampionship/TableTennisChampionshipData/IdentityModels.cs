using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using TableTennisChampionship.Model.DataBaseModel;
using TableTennisChampionshipData.Migrations;

namespace TableTennisChampionshipData
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual Player Player {get; set;}
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public virtual IDbSet<Tournament> Tournaments { get; set; }
        public virtual IDbSet<TournamentType> TournamentTypes { get; set; }
        public virtual IDbSet<Stage> Stages { get; set; }
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<MatchRule> MatchRules { get; set; }
        public virtual IDbSet<Match> Matchs { get; set; }
        public virtual IDbSet<Game> Games { get; set; }
        public virtual IDbSet<AdvanceGroupCriteria> AdvanceGroupCriterias { get; set; }
        public virtual IDbSet<TournamentPlayer> TournamentPlayer { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
       
    }
}