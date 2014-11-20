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
   //public  class TableTennisDbContext : DbContext
   // {
   //    public TableTennisDbContext()
   //        : base("TableTennis") 
   //    { 
   //    }

   //     public virtual IDbSet<Tournament> Tournaments { get; set; }
   //     public virtual IDbSet<TournamentType> TournamentTypes { get; set; }
   //     public virtual IDbSet<Stage> Stages { get; set; }
   //     public virtual IDbSet<Player> Players { get; set; }
   //     public virtual IDbSet<MatchRule> MatchRules { get; set; }
   //     public virtual IDbSet<Match> Matchs { get; set; }
   //     public virtual IDbSet<Game> Games { get; set; }
   //     public virtual IDbSet<AdvanceGroupCriteria> AdvanceGroupCriterias { get; set; }

   //     protected override void OnModelCreating(DbModelBuilder modelBuilder)
   //     {
   //         modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
   //     }

   // }
}
