using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AppDev.Models;

namespace AppDev.Data.Seed
{
    public static class Seeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "ASP.NET",
                    Description = "Welcome to class ASP.NET"
                }) ;
  
        }
    }
}
