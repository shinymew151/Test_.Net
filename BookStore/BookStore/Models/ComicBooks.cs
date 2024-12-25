using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class ComicBooks
{
    [Key]
    public int ComicBookID { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public long PricePerDay { get; set; }
}