using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chicken.Contract.Farm;

namespace Chicken.EF
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=Chicken")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Farm DB Schema

            modelBuilder.Entity<Registration>().ToTable("Registration", "Farm");

            #endregion Farm DB Schema
        }


        #region Farm Schema
        public virtual DbSet<Registration> Registrations { get; set; }
        #endregion Farm Schema
    }
}
