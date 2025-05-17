using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public int FacilityID { get; set; }
        public Facility Facility { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public string? Caption { get; set; }
        public DateTime UploadDate { get; set; }
        public bool IsMainImage { get; set; }
    }
} 