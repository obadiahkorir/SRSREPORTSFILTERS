using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext() { } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Ward> Wards { get; set; }
        public DbSet<SubLocation> SubLocations { get; set; }
        public DbSet<Constituency> Constituencies { get; set; }
        public DbSet<NicheListingHousehold> NicheListingHouseholds { get; set; }
        public DbSet<NicheListingHouseholdMember> NicheListingHouseholdMembers { get; set; }

        public DbSet<HouseholdMembers> HouseHoldMembers { get; set; }

        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }

        public DbSet<SystemCode> SystemCodes { get; set; }

    }
}