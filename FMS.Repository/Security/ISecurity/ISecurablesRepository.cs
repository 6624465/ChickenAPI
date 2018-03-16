using FMS.Contract.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository.Security.ISecurity
{
    public interface ISecurablesRepository : IRepository<Securables>, IDisposable
    {
    }
}
