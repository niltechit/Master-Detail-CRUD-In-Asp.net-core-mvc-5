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
    public class BillService : IBillService
    {
        private readonly ISqlDataAccess _db;

        public BillService(ISqlDataAccess db)
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

        public async Task<List<EntryViewModel>> GetAll()
        {
            return await _db.LoadDataUsingProcedure<EntryViewModel, dynamic>(storedProcedure: "dbo.GetAllCustomer", new { });
        }

        public async Task<EntryViewModel> GetById(int CUSTID)
        {
            var result = await _db.LoadDataUsingProcedure<EntryViewModel, dynamic>(storedProcedure: "dbo.SP_GetCustomerById", new { CUSTID = CUSTID });
            return result.FirstOrDefault();
        }

        public async Task<Response<int>> Insert(EntryViewModel customer)
        {
            customer.BILLDATE = DateTime.Now;
            var response = new Response<int>();
            try
            {
                var newId = await _db.SaveDataUsingProcedureAndReturnId<short, dynamic>(storedProcedure: "dbo.SP_BillHeaderInsert", new
                {
                   customer.BILLNO,
                   customer.CUSTID,
                   customer.BILLDATE
                });

               // var newId = customer.BILLHEADERTABLE.BILLID;
                response.Result = newId;
                response.IsSuccess = true;

                //var billId = await _db.SaveDataUsingProcedureAndReturnId<short, dynamic>(storedProcedure: "dbo.SP_BillHeaderInsert", new
                //{
                //    customer.BILLHEADERTABLE.BILLNO,
                //    customer.CustomerId,
                //    customer.BILLHEADERTABLE.BILLDATE
                //});

                //response.Result = billId;
                //response.IsSuccess = true;

                if (response.IsSuccess == true && customer.Items.Count>0)
                {
                    foreach (var item in customer.Items)
                    {
                        customer.ITEMID = item.ITEMID;
                        customer.BILLID = newId;
                        customer.BILLQTY = item.STOCKQTY;
                        customer.RATE = item.RATE;
                        var itemId = await _db.SaveDataUsingProcedureAndReturnId<short, dynamic>(storedProcedure: "dbo.SP_BillDetailInsert", new
                        {
                            customer.ITEMID,
                            customer.BILLID,
                            customer.BILLQTY,
                            customer.RATE
                        });
                        response.Result = itemId;
                    }
                }

            }
            catch (Exception ex)
            {
                
            }

            return response;
        }

        public async Task<Response<bool>> Update(EntryViewModel customer)
        {
            var response = new Response<bool>();

            try
            {
                await _db.SaveDataUsingProcedure(storedProcedure: "dbo.SP_CustomerUpdate", new
                {
                   
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
