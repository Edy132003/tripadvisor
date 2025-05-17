using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class RegularUser
    {
        [Key]
        public int UserID { get; set; }
        public User User { get; set; } = null!;
        public int ReviewCount { get; set; }
        public DateTime LastReviewDate { get; set; }
        public string Preferences { get; set; } = string.Empty;
        public string RecentSearches { get; set; } = string.Empty;
    }
} 