using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ITSMProject.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public int? TeamId { get; set; }
    public virtual Team? Team { get; set; }
    
    public string? ProfilePicture { get; set; }
}

public class Team
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual ICollection<ApplicationUser> Members { get; set; } = [];
    
    public virtual ApplicationUser? TeamLead { get; set; }
    public int? TeamLeadId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class UserTeam
{
    public int UserId { get; set; }
    public virtual ApplicationUser User { get; set; } = null!;
    
    public int TeamId { get; set; }
    public virtual Team Team { get; set; } = null!;
}

public class ApplicationRole : IdentityRole<int>
{
    public string Description { get; set; }
    
    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}

public class TicketCategory
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<TicketSubCategory> SubCategories { get; set; } = new List<TicketSubCategory>();

}

public class TicketSubCategory : TicketCategory
{
    public int ParentCategoryId { get; set; }
    public virtual TicketCategory ParentCategory { get; set; } = null!;
}

public class TicketStatus
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

public class TicketPriority
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

public class Ticket
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public int CategoryId { get; set; }
    public virtual TicketCategory Category { get; set; } = null!;
    
    public int StatusId { get; set; }
    public virtual TicketStatus Status { get; set; } = null!;
    
    public int PriorityId { get; set; }
    public virtual TicketPriority Priority { get; set; } = null!;
    
    public int CreatedById { get; set; }
    public virtual ApplicationUser CreatedBy { get; set; } = null!;
    
    public int? AssignedToId { get; set; }
    public virtual ApplicationUser? AssignedTo { get; set; }
    
    public virtual ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class TicketComment
{
    public int Id { get; set; }
    
    public string Comment { get; set; } = string.Empty;
    
    public int TicketId { get; set; }
    public virtual Ticket Ticket { get; set; } = null!;
    
    public int CreatedById { get; set; }
    public virtual ApplicationUser CreatedBy { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}