using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public enum ReportStatus
    {
        Pending,
        Resolved,
        Dismissed
    }

    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public int ReviewID { get; set; }
        public Review Review { get; set; } = null!;

        public int ReportedByUserID { get; set; }
        public User ReportedByUser { get; set; } = null!;

        public int? ResolvedByAdminID { get; set; }
        public Admin? ResolvedByAdmin { get; set; }

        [Required]
        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;

        public DateTime ReportDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public ReportStatus Status { get; set; }
        public string? ResolutionNotes { get; set; }
    }
} 