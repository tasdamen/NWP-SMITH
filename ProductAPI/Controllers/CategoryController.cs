using ProductAPI.Models;
using ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductAPI.Controllers
{
    public class CategoryController: ApiController
    {


        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            IEnumerable<Category> products = new List<Category>();
            return await CategoryRepository.Get(null);
        }


    }
}
