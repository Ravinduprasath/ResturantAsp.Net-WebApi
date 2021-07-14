using DataAcceessLibrary.DataAccess;
using DataAcceessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLibrary.BussinessLogic
{
    public static class FoodClass
    {
        public static List<FoodModel> LoadFood() 
        {
            return DataAccessClass.LoadFood<FoodModel>("spGetAll_Food");
        }
    }
}
