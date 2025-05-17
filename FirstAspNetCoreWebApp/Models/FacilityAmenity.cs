using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class FacilityAmenity
    {
        public int FacilityID { get; set; }
        public Facility Facility { get; set; } = null!;

        public int AmenityID { get; set; }
        public Amenity Amenity { get; set; } = null!;
    }
} 