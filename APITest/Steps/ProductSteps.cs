using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace APITest.Steps
{
    [Binding]
    public class ProductSteps
    {
        [Given(@"I am a merchendiser interested in product management")]
        public void GivenIAmAMerchendiserInterestedInProductManagement()
        {
            //Todo: Authorization should pass here
        }
        
        [When(@"I query for all products")]
        public void WhenIQueryForAllProducts()
        {
            ScenarioContext.Current.Add(typeof(HttpWebResponse).Name, WebRequest.CreateHttp("http://adm-newpapi:9000/api/product").GetResponse());
        }
        
        [Then(@"I am returned all saved products")]
        public void ThenIAmReturnedAllSavedProducts()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(typeof(HttpWebResponse).Name));
            HttpWebResponse response = ScenarioContext.Current.Get<HttpWebResponse>(typeof(HttpWebResponse).Name);
            Assert.IsTrue(response.ContentType.StartsWith("application/json"));
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string output = stream.ReadToEnd();
                JArray products = JsonConvert.DeserializeObject<JArray>(output);
                Assert.IsTrue(products.Count > 0);
            }

        }
    }
}
