using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int FacilityID { get; set; }
        public Facility Facility { get; set; } = null!;

        public int UserID { get; set; }
        public User User { get; set; } = null!;

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;

        public DateTime ReviewDate { get; set; }
        public bool IsVerified { get; set; }
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
} 