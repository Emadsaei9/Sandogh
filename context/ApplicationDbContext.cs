using Microsoft.EntityFrameworkCore;
using Sandogh.Models;

namespace Sandogh.context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // پیکربندی رابطه بین Member و Investment
            modelBuilder.Entity<Investment>()
                .HasOne(i => i.Member) // هر سرمایه‌گذاری یک عضو دارد
                .WithMany(m => m.Investment) // یک عضو می‌تواند چندین سرمایه‌گذاری داشته باشد
                .HasForeignKey(i => i.MemberId) // کلید خارجی به MemberId مربوط است
                .OnDelete(DeleteBehavior.Cascade); // هنگام حذف عضو، سرمایه‌گذاری‌های آن هم حذف شوند
        }
    }
}
