using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chicken.Contract.Security;

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

            #region Security DB Schema

            modelBuilder.Entity<Registration>().ToTable("Registration", "Security");

            #endregion Security DB Schema
        }


        #region Security Schema
        public virtual DbSet<Registration> Registrations { get; set; }
        #endregion Security Schema
    }
}
