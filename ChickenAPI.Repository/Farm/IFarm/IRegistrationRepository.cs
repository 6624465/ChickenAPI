using Chicken.Contract.Farm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Repository.Farm.IFarm
{
    public interface IRegistrationRepository : IRepository<Registration>, IDisposable
    {
        void UpdateOTPStatus(Registration reg);
    }
}
