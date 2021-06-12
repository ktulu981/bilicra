using bilicra.Models;
using Microsoft.EntityFrameworkCore;

namespace bilicra.dataaccess{
public class Datacontext:DbContext{

    public Datacontext(DbContextOptions options):base(options)
    {
        
    }


    public DbSet<Product> Products { get; set; }
    
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Bilicra");
    }
}
}
