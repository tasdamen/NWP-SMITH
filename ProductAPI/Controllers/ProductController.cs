using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductAPI
{
    public class ProductController : ApiController
    {
        [HttpGet()]
        public async Task<IEnumerable<Product>> Get(int id)
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.Get(null);
        }
    }
}
