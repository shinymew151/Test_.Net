using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Rental
{
    [Key]
    public int RentalId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Status { get; set; }
    public Customer Customer { get; set; }
}