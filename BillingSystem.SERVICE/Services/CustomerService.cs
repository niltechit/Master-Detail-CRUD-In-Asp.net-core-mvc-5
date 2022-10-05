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
    public class CustomerService : ICustomerService
    {
        private readonly ISqlDataAccess _db;

        public CustomerService(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<Response<bool>> Delete(int CUSTID)
        {
            var response = new Response<bool>();

            try
            {
                await _db.SaveDataUsingProcedure(storedProcedure: "dbo.SP_CustomerDelete", new { CUSTID = CUSTID });
                response.IsSuccess = true;
                
            }
            catch (Exception ex)
            {
                
            }

            return response;
        }

        public async Task<List<CUSTOMER>> GetAll()
        {
            return await _db.LoadDataUsingProcedure<CUSTOMER, dynamic>(storedProcedure: "dbo.GetAllCustomer", new { });
        }

        public async Task<CUSTOMER> GetById(int CUSTID)
        {
            var result = await _db.LoadDataUsingProcedure<CUSTOMER, dynamic>(storedProcedure: "dbo.SP_GetCustomerById", new { CUSTID = CUSTID });
            return result.FirstOrDefault();
        }

        public async Task<Response<int>> Insert(CUSTOMER customer)
        {
            var response = new Response<int>();
            try
            {
                var newId = await _db.SaveDataUsingProcedureAndReturnId<short, dynamic>(storedProcedure: "dbo.SP_CustomerInsert", new
                {
                   customer.CUSTID,
                   customer.CUSTNAME
                });

                
                response.Result = newId;
                response.IsSuccess = true;


            }
            catch (Exception ex)
            {
                
            }

            return response;
        }

        public async Task<Response<bool>> Update(CUSTOMER customer)
        {
            var response = new Response<bool>();

            try
            {
                await _db.SaveDataUsingProcedure(storedProcedure: "dbo.SP_CustomerUpdate", new
                {
                    customer.CUSTID,
                    customer.CUSTNAME
                });

                response.IsSuccess = true;
               
            }
            catch (Exception ex)
            {
                
            }

            return response;
        }
    }
}
