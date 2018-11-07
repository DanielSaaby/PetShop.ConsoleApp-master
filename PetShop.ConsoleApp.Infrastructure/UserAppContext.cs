
using Microsoft.EntityFrameworkCore;
using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Infrastructure
{
    public class UserAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
