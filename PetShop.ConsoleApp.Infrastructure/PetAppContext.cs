using Microsoft.EntityFrameworkCore;
using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Infrastructure
{
    public class PetAppContext : DbContext
    {

        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt)
        {
            //Constructor to Super class
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Pets)
                .WithOne(p => p.Owner)
                .OnDelete(DeleteBehavior.SetNull);
            
            

            


        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }
    }
}
