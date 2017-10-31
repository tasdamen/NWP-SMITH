using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI
{
    public static class CategoryRepository
    {
        public static async Task<IEnumerable<Category>> Get(int? categoryID)
        {
            IEnumerable<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = categoryID.HasValue ? Predicates.Field<Category>(f => f.CategoryID, Operator.Eq, categoryID.Value) : null;
                categories = await connection.GetListAsync<Category>(predicate);
                connection.Close();
            }

            return categories;
        }
        
        public static async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
               // var predicate = categoryID.HasValue ? Predicates.Field<Category>(f => f.ProductID, Operator.Eq, categoryID.Value) : null;
                categories = await connection.GetListAsync<Category>(null);
                connection.Close();
            }

            return categories;
        }
    }
}
