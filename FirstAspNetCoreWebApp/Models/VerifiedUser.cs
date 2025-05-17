using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class VerifiedUser
    {
        [Key]
        public int UserID { get; set; }
        public User User { get; set; } = null!;
        public int? FacilityID { get; set; }
        public Facility? Facility { get; set; }
        public DateTime VerificationDate { get; set; }
        public string VerificationDocument { get; set; } = string.Empty;
    }
} 