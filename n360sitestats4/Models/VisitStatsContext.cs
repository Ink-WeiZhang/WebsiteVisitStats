using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace n360sitestats4.Models
{
    public class VisitStatsContext : DbContext
    {
        public VisitStatsContext(DbContextOptions<VisitStatsContext> options) : base(options)
        {

        }

        public DbSet<Visit> Visits { get; set; }
    }
}
