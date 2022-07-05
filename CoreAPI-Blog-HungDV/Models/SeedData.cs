using CoreAPI_Blog_HungDV.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EntityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EntityContext>>()))
            {
                // Look for any entitys.
                if (context.Blogs.Any())
                {
                    return;   // DB has been seeded
                }
                context.SaveChanges();
            }
        }
    }
}
