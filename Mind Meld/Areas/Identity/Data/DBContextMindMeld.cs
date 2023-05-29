using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;

namespace Mind_Meld.Areas.Identity.Data;

public class DBContextMindMeld : IdentityDbContext<MindMeldUser>
{
    public DBContextMindMeld(DbContextOptions<DBContextMindMeld> options)
          : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
    public DbSet<Dept> Dept { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<PO_DTL> PO_DTL { get; set; }
    public DbSet<PR_DTL> PR_DTL { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Purch_Order> Purch_Order { get; set; }
    public DbSet<Purch_Request> Purch_Request { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
    public DbSet<PurchRequest> PurchRequest { get; set; }


}
