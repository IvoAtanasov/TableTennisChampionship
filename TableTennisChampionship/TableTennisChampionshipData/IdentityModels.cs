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
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }


       
    }
}