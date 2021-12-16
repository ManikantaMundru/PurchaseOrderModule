using PurchaseOrderModule.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Repository.Contracts
{
   public interface IDapperRepository
    {
        Task<T> QueryOne<T>(DbConnection connection) where T : new();
        Task<IList<T>> QueryList<T>(DbConnection connection) where T : new();
        Task<int> Execute(DbConnection connection);
    }
}
