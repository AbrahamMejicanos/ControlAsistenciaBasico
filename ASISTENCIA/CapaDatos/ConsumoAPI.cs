using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaDatos
{
    public class ConsumoAPI
    {
        public dynamic Get(string url) {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myhttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myhttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            //leo datos
            string datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(datos);
            return data;
        }
    }
}
