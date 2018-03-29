using FMS.Contract.Farm;
using FMS.EF;
using FMS.Repository.Config;
using FMS.Repository.Config.IConfig;
using FMS.Repository.Farm;
using FMS.Repository.Farm.IFarm;
using FMS.Repository.Security;
using FMS.Repository.Security.ISecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMS.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DBContext entities = null;
        public UnitOfWork()
        {
            entities = new DBContext();
        }

        #region Farm Repository

        IRegistrationRepository registrationRepository = null;
        public IRegistrationRepository RegistrationRepository
        {
            get
            {
                if (registrationRepository == null)
                {
                    registrationRepository = new RegistrationRepository(entities);
                }
                return registrationRepository;
            }
        }

        IFarmProfileRepository farmProfileRepository = null;
        public IFarmProfileRepository FarmProfileRepository
        {
            get
            {
                if (farmProfileRepository == null)
                {
                    farmProfileRepository = new FarmProfileRepository(entities);
                }
                return farmProfileRepository;
            }
        }

        IAnimalProfileRepository animalProfileRepository = null;
        public IAnimalProfileRepository AnimalProfileRepository
        {
            get
            {
                if (animalProfileRepository == null)
                {
                    animalProfileRepository = new AnimalProfileRepository(entities);
                }
                return animalProfileRepository;
            }
        }

        IExpensesEntryRepository expensesEntryRepository = null;
        public IExpensesEntryRepository ExpensesEntryRepository
        {
            get
            {
                if (expensesEntryRepository == null)
                {
                    expensesEntryRepository = new ExpensesEntryRepository(entities);
                }
                return expensesEntryRepository;
            }
        }

        IExpensesMasterRepository expensesMasterRepository = null;
        public IExpensesMasterRepository ExpensesMasterRepository
        {
            get
            {
                if (expensesMasterRepository == null)
                {
                    expensesMasterRepository = new ExpensesMasterRepository(entities);
                }
                return expensesMasterRepository;
            }
        }

        IMedicineMasterRepository medicineMasterRepository = null;
        public IMedicineMasterRepository MedicineMasterRepository
        {
            get
            {
                if (medicineMasterRepository == null)
                {
                    medicineMasterRepository = new MedicineMasterRepository(entities);
                }
                return medicineMasterRepository;
            }
        }

        ITransporterHeaderRepository transporterHeaderRepository = null;
        public ITransporterHeaderRepository TransporterHeaderRepository
        {
            get
            {
                if (transporterHeaderRepository == null)
                {
                    transporterHeaderRepository = new TransporterHeaderRepository(entities);
                }
                return transporterHeaderRepository;
            }
        }

        ITransporterRouteRepository transporterRouteRepository = null;
        public ITransporterRouteRepository TransporterRouteRepository
        {
            get
            {
                if (transporterRouteRepository == null)
                {
                    transporterRouteRepository = new TransporterRouteRepository(entities);
                }
                return transporterRouteRepository;
            }
        }

        ITreatmentEntryRepository treatmentEntryRepository = null;
        public ITreatmentEntryRepository TreatmentEntryRepository
        {
            get
            {
                if (treatmentEntryRepository == null)
                {
                    treatmentEntryRepository = new TreatmentEntryRepository(entities);
                }
                return treatmentEntryRepository;
            }
        }

        IVaccineEntryRepository vaccineEntryRepository = null;
        public IVaccineEntryRepository VaccineEntryRepository
        {
            get
            {
                if (vaccineEntryRepository == null)
                {
                    vaccineEntryRepository = new VaccineEntryRepository(entities);
                }
                return vaccineEntryRepository;
            }
        }

        IVaccineMasterRepository vaccineMasterRepository = null;
        public IVaccineMasterRepository VaccineMasterRepository
        {
            get
            {
                if (vaccineMasterRepository == null)
                {
                    vaccineMasterRepository = new VaccineMasterRepository(entities);
                }
                return vaccineMasterRepository;
            }
        }

        IVaccineScheduleRepository vaccineScheduleRepository = null;
        public IVaccineScheduleRepository VaccineScheduleRepository
        {
            get
            {
                if (vaccineScheduleRepository == null)
                {
                    vaccineScheduleRepository = new VaccineScheduleRepository(entities);
                }
                return vaccineScheduleRepository;
            }
        }

        IStandardPriceRepository standardPriceRepository = null;
        public IStandardPriceRepository StandardPriceRepository
        {
            get
            {
                if (standardPriceRepository == null)
                {
                    standardPriceRepository = new StandardPriceRepository(entities);
                }
                return standardPriceRepository;
            }
        }
        #endregion Farm Repository


        #region security Repository

        IUserRepository userRepository = null;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(entities);
                }
                return userRepository;
            }
        }

        #endregion security Repository


        #region config Repository

        ILookupRepository lookupRepository = null;
        public ILookupRepository LookupRepository
        {
            get
            {
                if (lookupRepository == null)
                {
                    lookupRepository = new LookupRepository(entities);
                }
                return lookupRepository;
            }
        }

        #endregion config Repository




        public void SaveChanges()
        {
            entities.SaveChanges();
        }

        protected virtual void ConfigureContext(DBContext entities)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            entities.Configuration.LazyLoadingEnabled = false;
            entities.Configuration.ValidateOnSaveEnabled = false;
        }

        //private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            //if (!this.disposed)
            //{
            //    if (disposing)
            //    {
            //        entities.Dispose();
            //    }
            //}
            //this.disposed = true;
            if (!disposing)
            {
                return;
            }

            if (this.entities == null)
            {
                return;
            }

            this.entities.Dispose();
            this.entities = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}