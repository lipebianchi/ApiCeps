using Microsoft.EntityFrameworkCore;
using ApiCeps.Entities;

namespace ApiCeps.Context
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {

        }
        
        public DbSet<Address> FelipeAddress { get; set; }
    }
}