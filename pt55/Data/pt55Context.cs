using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pt55.Models;

namespace pt55.Data
{
    public class pt55Context : DbContext
    {
        public pt55Context (DbContextOptions<pt55Context> options)
            : base(options)
        {
        }

        public DbSet<pt55.Models.Services> Services { get; set; } = default!;

        public DbSet<pt55.Models.Categories>? Categories { get; set; }

        public DbSet<pt55.Models.Usersaccounts>? Usersaccounts { get; set; }

    }
}
