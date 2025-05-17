using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public enum AdminLevel
    {
        Regular,
        SuperAdmin
    }

    public class Admin
    {
        [Key]
        public int UserID { get; set; }
        public User User { get; set; } = null!;
        public AdminLevel AdminLevel { get; set; }
        public string Permissions { get; set; } = string.Empty;
        public DateTime LastActionTime { get; set; }
        public ICollection<AdminAction> AdminActions { get; set; } = new List<AdminAction>();
        public ICollection<Report> ResolvedReports { get; set; } = new List<Report>();
    }
} 