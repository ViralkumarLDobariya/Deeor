using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deeor.Models;

namespace Deeor.Data
{
    public class DeeorContext : DbContext
    {
        public DeeorContext (DbContextOptions<DeeorContext> options)
            : base(options)
        {
        }

        public DbSet<Deeor.Models.Bracelette> Bracelette { get; set; } = default!;
    }
}
