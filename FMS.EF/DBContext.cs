using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Contract.Config;
using FMS.Contract.Farm;
using FMS.Contract.Security;
using FMS.Contract.Utility;

namespace FMS.EF
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=FMS")
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
        public virtual DbSet<AnimalProfile> AnimalProfiles { get; set; }
        public virtual DbSet<ExpensesEntry> ExpensesEntrys { get; set; }
        public virtual DbSet<ExpensesMaster> ExpensesMasters { get; set; }
        public virtual DbSet<FarmProfile> FarmProfiles { get; set; }
        public virtual DbSet<MedicineMaster> MedicineMasters { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<TransporterHeader> TransporterHeaders { get; set; }
        public virtual DbSet<TransporterRoute> TransporterRoutes { get; set; }
        public virtual DbSet<TreatmentEntry> TreatmentEntrys { get; set; }
        public virtual DbSet<VaccineEntry> VaccineEntrys { get; set; }
        public virtual DbSet<VaccineMaster> VaccineMasters { get; set; }
        public virtual DbSet<VaccineSchedule> VaccineSchedules { get; set; }
        #endregion Farm Schema

        #region Security Schema
        public virtual DbSet<RoleRights> RoleRightss { get; set; }
        public virtual DbSet<Roles> Roless { get; set; }
        public virtual DbSet<Securables> Securabless { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRights> UserRightss { get; set; }
        #endregion Security Schema

        #region Utility Schema
        public virtual DbSet<DocumentNumberHeader> DocumentNumberHeaders { get; set; }
        public virtual DbSet<DocumentNumberDetail> DocumentNumberDetails { get; set; }
        #endregion Utility Schema


        #region Config Schema
        public virtual DbSet<Lookup> Lookups { get; set; }
        #endregion Config Schema
    }
}
