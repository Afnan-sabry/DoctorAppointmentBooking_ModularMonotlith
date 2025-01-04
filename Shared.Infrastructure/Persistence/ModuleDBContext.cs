using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Persistence
{
    public class ModuleDBContext(DbContextOptions options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}
