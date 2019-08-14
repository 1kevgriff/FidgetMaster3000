using System;
using System.Linq;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FidgetPro.Fidgetmaster.Business.Database
{
    public class FidgetContext : DbContext
    {
        public FidgetContext(DbContextOptions<FidgetContext> options)
            : base(options)
        {

        }
        public DbSet<Fidget> Fidgets { get; set; }
        public DbSet<FidgetType> FidgetTypes { get; set; }
        public DbSet<FidgetUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FidgetType>().HasData(new FidgetType()
                {
                    Id = 1,
                    TypeName = "Thingamajig",
                    DesignedDate = DateTime.UtcNow,
                    IsBouncing = false,
                    IsFlying = true,
                    IsSpinning = true
                }, new FidgetType()
                {
                    Id = 2,
                    TypeName = "Domaflotitch",
                    DesignedDate = DateTime.UtcNow,
                    IsBouncing = true,
                    IsFlying = false,
                    IsSpinning = true
                },
                new FidgetType()
                {
                    Id = 3,
                    TypeName = "Chad",
                    DesignedDate = DateTime.UtcNow,
                    IsBouncing = false,
                    IsFlying = false,
                    IsSpinning = false
                });

            modelBuilder.Entity<Fidget>().HasData(new Fidget()
            {
                Color = "Green", Id = 1, Name = "Foo", TypeId = 2
            });

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

    }
}
