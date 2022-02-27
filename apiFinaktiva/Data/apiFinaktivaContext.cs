#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiFinaktiva.Models;

namespace apiFinaktiva.Data
{
    public class apiFinaktivaContext : DbContext
    {
        public apiFinaktivaContext (DbContextOptions<apiFinaktivaContext> options)
            : base(options)
        {
        }

        public DbSet<apiFinaktiva.Models.Users> Users { get; set; }
    }
}
