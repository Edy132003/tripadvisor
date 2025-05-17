using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class SearchLog
    {
        [Key]
        public int SearchLogID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }

        [Required]
        public string SearchQuery { get; set; } = string.Empty;

        public string? Filters { get; set; }
        public DateTime SearchDate { get; set; }
        public string? Location { get; set; }
        public int? ResultCount { get; set; }
    }
} 