using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.SERVICE.Interface
{
    public interface IBillService
    {
        Task<Response<bool>> Delete(int orderId);
        Task<List<EntryViewModel>> GetAll();
        Task<EntryViewModel> GetById(int orderId);
        Task<Response<int>> Insert(EntryViewModel model);
        Task<Response<bool>> Update(EntryViewModel model);
        
    }
}
