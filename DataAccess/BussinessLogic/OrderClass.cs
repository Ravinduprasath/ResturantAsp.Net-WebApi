using Dapper;
using DataAcceessLibrary.DataAccess;
using DataAcceessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLibrary.BussinessLogic
{
    public static class OrderClass
    {
        public static List<OrderModel> LoadOrder() 
        {

            string sql = "select * from dbo.FoodOrder";

            return DataAccessClass.LoadData<OrderModel>(sql);
        }

        public static int InsertOrder(string name, string address, int foodid, int quantity,
            decimal total)
        {
            /*  OrderModel order = new OrderModel
              {   
                  PersonName = name,
                  PersonAddress = address,
                  FoodId = foodid,
                  Quantity = quantity,
                  Total = total
              };


              DataAccessClass.SaveData<OrderModel>(@"spInsert_Order @PersonName, @PersonAddress, 
                                                   @FoodId, @Quantity, @Total", order);
            */

            var p = new DynamicParameters();
            p.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@PersonName", name);
            p.Add("@PersonAddress", address);
            p.Add("@FoodId", foodid);
            p.Add("@Quantity", quantity);
            p.Add("@Total", total);

            string sql = $@"Insert Into dbo.FoodOrder(PersonName, PersonAddress, FoodId, Quantity, Total)
	                        Values (@PersonName, @PersonAddress, @FoodId, @Quantity, @Total);
	                        Set @Id = @@IDENTITY;";

            DataAccessClass.SaveData(sql, p);

            int idenity = p.Get<int>("@Id");

            return idenity;
        }

        public static int UpdateOrder(int id, string name, string address, int foodid, int quantity,
            decimal total)
        {
            OrderModel order = new OrderModel
            {
                Id = id,
                PersonName = name,
                PersonAddress = address,
                FoodId = foodid,
                Quantity = quantity,
                Total = total
            };

            return DataAccessClass.SaveData<OrderModel>(@"spUpdate_Order @Id, @PersonName, @PersonAddress, 
                                                    @FoodId, @Quantity, @Total", order);
        }

        public static int DeleteOrder(int id) 
        {
           return DataAccessClass.SaveData("spDelete_Order @Id", new { Id = id });
        }
    }
}
