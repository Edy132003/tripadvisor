using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public enum ActionType
    {
        UserVerification,
        FacilityVerification,
        ReviewModeration,
        ReportResolution,
        ContentModeration
    }

    public class AdminAction
    {
        [Key]
        public int ActionID { get; set; }
        public int AdminID { get; set; }
        public Admin Admin { get; set; } = null!;

        public ActionType ActionType { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; }
        public string? AffectedEntityID { get; set; }
        public string? ActionDetails { get; set; }
    }
} 