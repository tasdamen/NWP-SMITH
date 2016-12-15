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
    public static class ProductRepository
    {
        public static async Task<IEnumerable<Product>> Get(int? productId)
        {
            IEnumerable<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = productId.HasValue ? Predicates.Field<Product>(f => f.ProductID, Operator.Eq, productId.Value) : null;
                products = await connection.GetListAsync<Product>(predicate);
                connection.Close();
            }

            return products;
        }
    }
}
