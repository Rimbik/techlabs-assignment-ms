using System.Net;
using System.Text;

namespace BlogAPIClient
{
    public static class BlogAPICient
    {
        public static string GetApi(string ApiUrl)
        {
            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;
            
        }
        public static string PostApi(string ApiUrl, string postData = "")
        {
            //var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            //var data = Encoding.ASCII.GetBytes(postData);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.ContentLength = data.Length;
            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}
            //var response = (HttpWebResponse)request.GetResponse();
            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //return responseString;

         //   var json = JsonConvert.SerializeObject(postData);
            var data = new StringContent(postData, Encoding.UTF8, "application/json");

            var url = ApiUrl;
            using var client = new HttpClient();

            var response = client.PostAsync(url, data).Result;

            var responseText = response.Content.ReadAsStringAsync().Result;
            return responseText;
        }
    }
}