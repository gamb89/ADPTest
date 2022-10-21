using ADPTest.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Repository.Context
{
    public class AdpContext : DbContext
    {
        public AdpContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) {  }
        public DbSet<TaskResult> TaskResult { get; set; }



    }
}
