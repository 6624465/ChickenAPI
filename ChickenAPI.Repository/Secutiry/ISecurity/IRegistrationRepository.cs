using Chicken.Contract.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Repository.Secutiry.ISecurity
{
    public interface IRegistrationRepository : IRepository<Registration>, IDisposable
    {
    }
}
