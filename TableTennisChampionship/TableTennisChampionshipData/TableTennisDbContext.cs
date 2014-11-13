using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTennisChampionship.Model.DataBaseModel;

namespace TableTennisChampionshipData
{
   public  class TableTennisDbContext : DbContext
    {
       public TableTennisDbContext()
           : base("TableTennis") 
       { 
       }

        public virtual IDbSet<Tournament> Tournament { get; set; }
        public virtual IDbSet<TournamentType> TournamentType { get; set; }
        public virtual IDbSet<Stage> Stage { get; set; }
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<MatchRule> MatchRule { get; set; }
        public virtual IDbSet<Match> Match { get; set; }
        public virtual IDbSet<Game> Game { get; set; }
        public virtual IDbSet<AdvanceGroupCriteria> AdvanceGroupCriteria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
