using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITSMProject.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, int>(options)
{
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<TicketCategory> TicketCategories { get; set; } = null!;
    public DbSet<TicketSubCategory> TicketSubCategories { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<TicketStatus> TicketStatuses { get; set; } = null!;
    public DbSet<TicketPriority> TicketPriorities { get; set; } = null!;
    public DbSet<TicketComment> TicketComments { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Configure ApplicationUser.Team relationship
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Team)
            .WithMany(t => t.Members)
            .HasForeignKey(u => u.TeamId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure TicketSubCategory to only allow parent of type TicketCategory (not TicketSubCategory)
        builder.Entity<TicketSubCategory>()
            .HasOne(tsc => tsc.ParentCategory)
            .WithMany(tc => tc.SubCategories)
            .HasForeignKey(tsc => tsc.ParentCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Add a check constraint to ensure parent is not a sub-category
        builder.Entity<TicketSubCategory>()
            .ToTable(tb => tb.HasCheckConstraint("CK_TicketSubCategory_ParentNotSub", 
                "ParentCategoryId NOT IN (SELECT Id FROM TicketSubCategories)"));
    }
}
