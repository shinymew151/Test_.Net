using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class ComicStoreDatabaseContext : DbContext
{
    public ComicStoreDatabaseContext(DbContextOptions<ComicStoreDatabaseContext> options)
        : base(options)
    {}
    
    public DbSet<ComicBooks> ComicBooks { get; set; } = default!;
    
    public DbSet<Customer> Customers { get; set; } = default!;
    
    public DbSet<Rental> Rentals { get; set; } = default!;
    
    public DbSet<RentalDetails> RentalDetails { get; set; } = default!;
}