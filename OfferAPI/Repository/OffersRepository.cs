using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAPI.Repository
{
    public class OffersRepository
    {
        private const string OffersPath = @"C:\NWP-SMITH\Offers";
        public static  List<Offer> GetAllOffers()
        {
            if (Directory.Exists(OffersPath))
            {
                 return Directory.GetFiles(OffersPath)
                    .Select(file =>
                    {
                        var fileTextContent = File.ReadAllText(file);
                        try
                        {
                            return Newtonsoft.Json.JsonConvert.DeserializeObject<Offer>(fileTextContent);
                        }
                        catch
                        {
                            // Ignore any errors for a given file.
                            // We may log issue here as well
                            return null;
                        }

                    })
                    .Where(offer => offer != null).ToList();
            }
            else
                return new List<Offer>();
        }

    }
}
