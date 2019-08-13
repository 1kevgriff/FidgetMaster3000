using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FidgetPro.Fidgetmaster.Web.Database
{
    public class FidgetContext: DbContext
    {
        public FidgetContext(DbContextOptions<FidgetContext> options)
            : base(options)
        {
            
        }
        public DbSet<Fidget> Fidgets { get; set; }
        public DbSet<FidgetType> FidgetTypes { get; set; }
    }
}
