using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDBContex : DbContext
    {
        public ApplicationDBContex(DbContextOptions<ApplicationDBContex> options) : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<QueryQuestions> Questions { get; set; }
        public DbSet<QueryAnswers> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can set schema for each entity separately if required
            modelBuilder.Entity<QueryQuestions>().ToTable("QueryQuestions", schema: "ZXNWVR");
            modelBuilder.Entity<QueryAnswers>().ToTable("QueryAnswers", schema: "ZXNWVR");

        }
    }
}
