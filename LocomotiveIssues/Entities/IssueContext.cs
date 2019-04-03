using System.Data.Entity;

namespace LocomotiveIssues.Entities
{
    public class IssueContext : DbContext
    {
        public IssueContext(): base("IssueDB")
        {

        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueCategory> IssuesCategories { get; set; }
        public DbSet<Locomotive> Locomotives { get; set; }
        public DbSet<User> Users { get; set; }
    }
}