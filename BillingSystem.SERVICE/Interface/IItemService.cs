using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.SERVICE.Interface
{
    public interface IItemService
    {
        Task<Response<bool>> Delete(int itemId);
        Task<List<ITEMTABLE>> GetAll();
        Task<ITEMTABLE> GetById(int itemId);
        Task<Response<int>> Insert(ITEMTABLE Item);
        Task<Response<bool>> Update(ITEMTABLE Item);
        
    }
}
