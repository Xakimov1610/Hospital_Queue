using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_queue.Entities;

public class Queue
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    public string Fullname { get; set; }

    [Required, RegularExpression(
        @"^[\+]?(998[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{3}[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{2}[-\s\.]?)$",
        ErrorMessage = "Telefon raqam formati noto'g'ri.")]
    public string PhoneNumber { get; set; }

    public ulong Number { get; set; }

    public bool Active { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    public DateTimeOffset ServiceTime { get; set; }

    public Queue(string fullname, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Fullname = fullname;
        PhoneNumber = phoneNumber;
        Active = false;
        CreatedAt = DateTimeOffset.UtcNow;
        ModifiedAt = default(DateTimeOffset);
        ServiceTime = default(DateTimeOffset);
    }
}