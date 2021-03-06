﻿using FMS.Contract.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace FMS.Repository.Security.ISecurity
{
    public interface IRoleRepository : IRepository<Contract.Security.Roles>, IDisposable
    {
    }
}
