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
                    .Select(Id => $"<a href=\"{request.Url}{Id}\"> Best Offer for product: {Id}</a></br><a href=\"{request.Url}All/{Id}\">All offers for product: {Id}</a>"));

            }
            else if (route.StartsWith("/All/"))
            {
                var rawProductId = route.Substring(5);
                int productId;
                if (int.TryParse(rawProductId, out productId))
                {
                    return OffersRepository.GetAllOffers(productId);
                }
                return "Invalid product Id";
            }
            else
            {
                var rawProductId = route.Substring(1);
                int productId;
                if(int.TryParse(rawProductId, out productId))
                {
                    return OffersRepository.GetBestOffer(productId);
                }
                return "Invalid product Id";
            }
        }
    }
}
