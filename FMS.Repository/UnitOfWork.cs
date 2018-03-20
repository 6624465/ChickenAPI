using FMS.Contract.Farm;
using FMS.EF;
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