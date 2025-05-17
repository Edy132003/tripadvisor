using System.ComponentModel.DataAnnotations;
using FirstAspNetCoreWebApp.Models;

namespace FirstAspNetCoreWebApp.Models
{
    public class Facility
    {
        [Key]
        public int FacilityID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public FacilityType Type { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public bool IsVerified { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        // Navigation properties
        public Location Location { get; set; } = null!;
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<FacilityAmenity> FacilityAmenities { get; set; } = new List<FacilityAmenity>();
        public VerifiedUser? Manager { get; set; }
    }
} 