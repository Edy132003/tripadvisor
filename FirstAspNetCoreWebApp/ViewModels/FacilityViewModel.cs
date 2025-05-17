using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using FirstAspNetCoreWebApp.Models;

namespace FirstAspNetCoreWebApp.ViewModels
{
    public class FacilityViewModel
    {
        public int FacilityID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public FacilityType Type { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public List<int> SelectedAmenities { get; set; } = new List<int>();

        public List<SelectListItem> FacilityTypes { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AmenityList { get; set; } = new List<SelectListItem>();
    }
} 