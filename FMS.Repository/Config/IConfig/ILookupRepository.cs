﻿using FMS.Contract.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository.Config.IConfig
{
    public interface ILookupRepository : IRepository<Lookup>, IDisposable
    {
    }
}
