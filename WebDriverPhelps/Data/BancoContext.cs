using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebDriverPhelps.Models;

namespace WebDriverPhelps.Data
{
    public class BancoContext : DbContext
        {
            public BancoContext(DbContextOptions<BancoContext> options) : base(options)
            {
            }

            public DbSet<ArModel> AR { get; set; }
            public DbSet<AcModel> AC { get; set; }


        }
    
}

