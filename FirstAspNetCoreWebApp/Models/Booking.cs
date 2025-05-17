using System.ComponentModel.DataAnnotations;

namespace FirstAspNetCoreWebApp.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }

    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public int FacilityID { get; set; }
        public Facility Facility { get; set; } = null!;

        public int UserID { get; set; }
        public User User { get; set; } = null!;

        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
        public string? SpecialRequests { get; set; }
    }
} 