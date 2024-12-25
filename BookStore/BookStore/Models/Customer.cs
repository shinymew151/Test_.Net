using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    public string FullName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public DateTime Registration { get; set; }
}