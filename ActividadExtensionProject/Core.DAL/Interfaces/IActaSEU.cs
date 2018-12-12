using ApplicationContext;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DAL.Interfaces
{
    public interface IActasEU
    {
        IQueryable<ActaEU> GetAll();
    }
}
