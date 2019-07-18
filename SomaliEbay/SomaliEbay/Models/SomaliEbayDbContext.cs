using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomaliEbay.Models
{
    public class SomaliEbayDbContext : DbContext
    {
        internal object product;

        //1-Create constructor

        public SomaliEbayDbContext(DbContextOptions<SomaliEbayDbContext> dbContext): base(dbContext)
        {
                
        }



        //2-create Model builder


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //3-add model classes as dbset

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }

    }
}
