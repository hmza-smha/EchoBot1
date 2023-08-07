using EchoBot1.Models;
using Microsoft.EntityFrameworkCore;

namespace EchoBot1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>().HasData(
              new TeamMember { MemberId = 1, MemberName = "Member 1" },
              new TeamMember { MemberId = 2, MemberName = "Member 2" },
              new TeamMember { MemberId = 3, MemberName = "Member 3" },
              new TeamMember { MemberId = 4, MemberName = "Member 4" },
              new TeamMember { MemberId = 5, MemberName = "Member 5" }
            );
        }
    }
}
