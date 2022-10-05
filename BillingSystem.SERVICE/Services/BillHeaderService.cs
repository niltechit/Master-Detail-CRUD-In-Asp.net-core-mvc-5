using BillingSystem.DAL.DA;
using BillingSystem.MODEL;
using BillingSystem.SERVICE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.SERVICE.Services
{
    public class BillHeaderService : IBillHeaderService
    {
        private readonly ISqlDataAccess _db;

        public BillHeaderService(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Response<bool>> Delete(int headerId)
        {
            var response = new Response<bool>();

            try
            {
                await _db.SaveDataUsingProcedure(storedProcedure: "dbo.SP_DeleteBillHeaderById", new { BILLID = headerId });
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public Task<List<BILLHEADERTABLE>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BILLHEADERTABLE> GetById(int headerId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> Insert(BILLHEADERTABLE model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Update(BILLHEADERTABLE model)
        {
            throw new NotImplementedException();
        }
    }
}
