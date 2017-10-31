using OfferAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OfferAPI
{
    public class DefaultController
    {
        public static string Get(HttpListenerRequest request)
        {
            var route = request.RawUrl;
            if (route == "/" || string.IsNullOrEmpty(route))
            {
                return String.Join("</br>", OffersRepository.GetAllOffers()
                    .SelectMany(offer =>
                    {
                        return offer.EligibleProducts;
                    }).Distinct()
                    .OrderBy(i => i)
                    .Select(Id => $"<a href=\"http://localhost:8081/{Id}\">{Id}</a>"));
                    
            }
            return "Not implemented";
        }
    }
}
