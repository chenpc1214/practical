using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Work.Models;

namespace Work.Data
{
    public class WorkContext : DbContext
    {
        public WorkContext (DbContextOptions<WorkContext> options)
            : base(options)
        {
        }

        public DbSet<Work.Models.Item> Item { get; set; }
    }
}
