using Chicken.Contract.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Repository.Security.ISecurity
{
    public interface IRoleRightsRepository : IRepository<RoleRights>, IDisposable
    {
    }
}
