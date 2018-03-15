using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chicken.Contract.Config;
using Chicken.Contract.Farm;
using Chicken.Contract.Security;
using Chicken.Contract.Utility;

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

            modelBuilder.Entity<AnimalProfile>().ToTable("AnimalProfile", "Farm");
            modelBuilder.Entity<ExpensesEntry>().ToTable("ExpensesEntry", "Farm");
            modelBuilder.Entity<ExpensesMaster>().ToTable("ExpensesMaster", "Farm");
            modelBuilder.Entity<FarmProfile>().ToTable("FarmProfile", "Farm");
            modelBuilder.Entity<MedicineMaster>().ToTable("MedicineMaster", "Farm");
            modelBuilder.Entity<Registration>().ToTable("Registration", "Farm");
            modelBuilder.Entity<TransporterHeader>().ToTable("TransporterHeader", "Farm");
            modelBuilder.Entity<TransporterRoute>().ToTable("TransporterRoute", "Farm");
            modelBuilder.Entity<TreatmentEntry>().ToTable("TreatmentEntry", "Farm");
            modelBuilder.Entity<VaccineEntry>().ToTable("VaccineEntry", "Farm");
            modelBuilder.Entity<VaccineMaster>().ToTable("VaccineMaster", "Farm");
            modelBuilder.Entity<VaccineSchedule>().ToTable("VaccineSchedule", "Farm");

            #endregion Farm DB Schema

            #region Security DB Schema

            modelBuilder.Entity<RoleRights>().ToTable("RoleRights", "Security");
            modelBuilder.Entity<Roles>().ToTable("Roles", "Security");
            modelBuilder.Entity<Securables>().ToTable("Securables", "Security");
            modelBuilder.Entity<User>().ToTable("User", "Security");
            modelBuilder.Entity<UserRights>().ToTable("UserRights", "Security");

            #endregion Security DB Schema

            #region Utility DB Schema

            modelBuilder.Entity<DocumentNumberHeader>().ToTable("DocumentNumberHeader", "Utility");
            modelBuilder.Entity<DocumentNumberDetail>().ToTable("DocumentNumberDetail", "Utility");

            #endregion Utility DB Schema

            #region Config DB Schema

            modelBuilder.Entity<Lookup>().ToTable("Lookup", "Config");

            #endregion Config DB Schema
        }


        #region Farm Schema
        public virtual DbSet<Registration> Registrations { get; set; }
        #endregion Farm Schema
    }
}
