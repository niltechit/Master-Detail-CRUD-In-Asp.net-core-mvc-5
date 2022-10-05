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
    public class ItemService : IItemService
    {
        private readonly ISqlDataAccess _db;

        public ItemService(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<Response<bool>> Delete(int ITEMID)
        {
            var response = new Response<bool>();

            try
            {
                await _db.SaveDataUsingProcedure(storedProcedure: "dbo.SP_ItemDelete", new { ITEMID = ITEMID });
                response.IsSuccess = true;
                
            }
            catch (Exception ex)
            {
                
            }

            return response;
        }

        public async Task<List<ITEMTABLE>> GetAll()
        {
            return await _db.LoadDataUsingProcedure<ITEMTABLE, dynamic>(storedProcedure: "dbo.SP_GetAllItem", new { });
        }

        public async Task<ITEMTABLE> GetById(int ITEMID)
        {
            var result = await _db.LoadDataUsingProcedure<ITEMTABLE, dynamic>(storedProcedure: "dbo.SP_GetItemById", new { ITEMID = ITEMID });
            return result.FirstOrDefault();
        }

        public async Task<Response<int>> Insert(ITEMTABLE customer)
        {
            var response = new Response<int>();
            try
            {
                var newId = await _db.SaveDataUsingProcedureAndReturnId<short, dynamic>(storedProcedure: "dbo.SP_ItemInsert", new
                {
                   customer.ITEMID,
                   customer.ITEMCODE,
                   customer.ITEMNAME,
                   customer.RATE,
                   customer.MOU,
                   customer.STOCKQTY
                });

                
                response.Result = newId;
                response.IsSuccess = true;


            }
            catch (Exception ex)
            {
                
            }

            return response;
        }

        public async Task<Response<bool>> Update(ITEMTABLE customer)
        {
            var response = new Response<bool>();

            try
            {
                await _db.SaveDataUsingProcedure(storedProcedure: "dbo.SP_ItemUpdate", new
                {
                    customer.ITEMID,
                    customer.ITEMCODE,
                    customer.ITEMNAME,
                    customer.RATE,
                    customer.MOU,
                    customer.STOCKQTY
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
