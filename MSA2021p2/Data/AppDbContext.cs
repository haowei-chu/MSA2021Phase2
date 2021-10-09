using Microsoft.EntityFrameworkCore;
using MSA2021p2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSA2021p2.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
