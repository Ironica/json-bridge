using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace JsonBridge
{
    public class JsonRequestHandler
    {
        public JsonRequestHandler(string url)
        {
            this._url = url;
        }

        private readonly string _url;
        private string _json;

        private string Result { get; set; }

        public JsonRequestHandler Feed(string json)
        {
            this._json = json;
            return this;
        }

        public JsonRequestHandler Fetch()
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(_url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(_json);
            }

            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                Result = streamReader.ReadToEnd();
            }

            return this;
        }

        public string get()
        {
            return Result;
        }
    }
}