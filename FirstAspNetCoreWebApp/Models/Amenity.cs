using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public ICollection<FacilityAmenity> FacilityAmenities { get; set; } = new List<FacilityAmenity>();
    }
} 