using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.SERVICE.Interface
{
    public interface ICustomerService
    {
        Task<Response<bool>> Delete(int customerId);
        Task<List<CUSTOMER>> GetAll();
        Task<CUSTOMER> GetById(int customerId);
        Task<Response<int>> Insert(CUSTOMER customer);
        Task<Response<bool>> Update(CUSTOMER customer);
        
    }
}
