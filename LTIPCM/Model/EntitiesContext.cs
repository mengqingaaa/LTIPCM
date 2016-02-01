using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace LTIPCM.Model
{
    class EntitiesContext : DbContext
    {
        public EntitiesContext()
            : base("LTIPCM")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Case> Cases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Entity<Case>().HasOptional<Client>(t => t.Client).WithMany(t => t.Cases);
        }
    }
}
