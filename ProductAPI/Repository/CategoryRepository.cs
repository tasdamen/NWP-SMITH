using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductAPI.Models;
using System.Data.SqlClient;
using DapperExtensions;
using System.Configuration;

namespace ProductAPI.Repository
{
    public class CategoryRepository
    {
        public static async Task<IEnumerable<Category>> Get(int? productId)
        {
            IEnumerable<Category> products = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = productId.HasValue ? Predicates.Field<Category>(f => f.CategoryID, Operator.Eq, productId.Value) : null;
                products = await connection.GetListAsync<Category>(predicate);
                connection.Close();
            }

            return products;
        }
    }
}
