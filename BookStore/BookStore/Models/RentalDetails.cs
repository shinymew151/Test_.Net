using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class RentalDetails
{
    [Key]
    public int RentalDetailId { get; set; }
    
    public int RentalId { get; set; }
    
    public int ComicBookId { get; set; }
    
    public long PricePerDay { get; set; }
    
}