using System.ComponentModel.DataAnnotations;

namespace Hospital_queue.ViewModels;

public class QueueViewModel
{
    public Guid Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Fullname { get; set; }

    [Required, RegularExpression(
        @"^[\+]?(998[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{3}[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{2}[-\s\.]?)$",
        ErrorMessage = "Telefon raqam formati noto'g'ri.")]
    public string PhoneNumber { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset ServiceTime { get; set; }
}