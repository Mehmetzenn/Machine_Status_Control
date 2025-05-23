﻿using Core.DataAccess;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IShiftDal: IEntityRepository<Shift>
    {
    }
}
