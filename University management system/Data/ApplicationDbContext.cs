using Microsoft.EntityFrameworkCore;
using University_management_system.Models;

namespace University_management_system.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Profile> Profiles { get; set; }

        //public DbSet<Schoolofengineering> schoolofengineeringstudents { get; set; }

        public DbSet<SchoolofPharmacy> schoolOfPharmacies { get; set; }

        public DbSet<SchoolOfHotelandCateringManagement> schoolOfHotelandCateringManagements { get; set; }
        public DbSet<SchoolOfManagementandCommerce> schoolOfManagementandCommerces { get; set; }

        public DbSet<SchoolOfLaw> schoolOfLaws { get; set; }
        public DbSet<SchoolofMusicFineArts> schoolofMusicFineArts { get; set; } 
        public DbSet<SchoolOfLanguages> schoolOfLanguages { get; set; }
        public DbSet<SchoolOfPhysiotherapy> schoolOfPhysiotherapies { get; set; }
        public DbSet<SchoolOfEngineering> schoolOfEngineerings { get; set; }


    }
}
