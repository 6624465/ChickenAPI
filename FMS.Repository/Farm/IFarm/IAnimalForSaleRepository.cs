﻿using FMS.Contract.Farm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository.Farm.IFarm
{
    public interface IAnimalForSaleRepository : IRepository<AnimalForSale>, IDisposable
    {
    }
}
