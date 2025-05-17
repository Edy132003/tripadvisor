using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public enum UserType
    {
        Regular,
        Verified,
        Admin
    }

    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int FailedLoginAttempts { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public RegularUser? RegularUser { get; set; }
        public VerifiedUser? VerifiedUser { get; set; }
        public Admin? Admin { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
} 