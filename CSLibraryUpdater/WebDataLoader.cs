using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace CSLibraryUpdater
{
    public static class WebDataLoader
    {
        private static readonly string _farnellTemplate = 
            @"http://api.element14.com//catalog/products?term=id%3A{0}&storeInfo.id=au.element14.com&resultsSettings.offset=0&resultsSettings.numberOfResults=1&resultsSettings.refinements.filters=&resultsSettings.responseGroup=large&callInfo.responseDataFormat=JSON&callinfo.apiKey=95wfpjeee8tdck8r63tbnxz7";


        public static Dictionary<string, string> LoadFromFarnell(string partNo)
        {
            var requestStr = string.Format(_farnellTemplate, partNo);
            var request = WebRequest.Create(requestStr);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            stream.Close();
            response.Close();

            var respObj = JsonConvert.DeserializeObject<ResponseFarnell>(responseFromServer);
            
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            if (respObj.premierFarnellPartNumberReturn.products.Count == 0) return keyValuePairs;
            var product = respObj.premierFarnellPartNumberReturn.products[0];

            keyValuePairs.Add("Manufacturer", product.brandName);
            keyValuePairs.Add("DisplayName", product.displayName);
            keyValuePairs.Add("ManufacturerPartNumber", product.translatedManufacturerPartNumber);

            int i = 1;
            foreach (var datasheet in product.datasheets)
            {
                keyValuePairs.Add("ComponentLink" + i.ToString() + "Description",
                    datasheet.description);
                keyValuePairs.Add("ComponentLink"+i.ToString()+"URL",
                    datasheet.url);
                i++;
            }

            foreach (var attribute in product.attributes)
            {
                keyValuePairs.Add(attribute.attributeLabel.Trim(), attribute.attributeValue.Trim());
            }

            return keyValuePairs;
        }

    }
}
