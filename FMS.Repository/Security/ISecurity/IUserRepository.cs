﻿using FMS.Contract.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository.Security.ISecurity
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
        void UpdatePassword(User reg);
    }
}
