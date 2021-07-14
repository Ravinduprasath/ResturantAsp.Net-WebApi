using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLibrary.DataAccess
{
    public static class DataAccessClass
    {
        public static string GetCon() 
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FoodDatabase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static List<T> LoadFood<T>(string sql) 
        {
            try
            {
                using (IDbConnection con = new SqlConnection(GetCon()))
                {
                    return con.Query<T>(sql).ToList();
                }
            }
            catch (Exception) 
            {
                return null;
            }
            
        }

        public static List<T> LoadData<T>(string sql)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(GetCon()))
                {
                    return con.Query<T>(sql).ToList();
                }
            }
            catch (Exception) 
            {
                return null;
            }
        }

        //For Insert, Update and Delete use this method
        public static int SaveData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(GetCon()))
                {
                    return con.Execute(sql, data);
                }
            }
            catch (Exception) 
            {
                return 0;
            }
        }
    }
}
