using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace tester
{
    /// <summary>
    /// Summary description for test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class test : System.Web.Services.WebService
    {

        [WebMethod]
        //public string[] HelloWorld()
        //{
        //    string check = string.Format("http://www.cnn.com/robots.txt");
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(check);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    List<string> disallow = new List<string>();
        //    string line;

        //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //    {
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            if (line.StartsWith("Disallow:"))
        //            {
        //                int index = line.IndexOf("/");
        //                disallow.Add("http://www.cnn.com" + line.Substring(index));
        //            }
        //        }
        //    }

        //    check = string.Format("http://www.money.cnn.com/robots.txt");
        //    request = (HttpWebRequest)WebRequest.Create(check);
        //    response = (HttpWebResponse)request.GetResponse();

        //    line = "";

        //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //    {
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            if (line.StartsWith("Disallow:"))
        //            {
        //                int index = line.IndexOf("/");
        //                disallow.Add("http://www.money.cnn.com" + line.Substring(index));
        //            }
        //        }
        //    }

        //    return disallow.ToArray<string>();
        //}

        public string[] HelloTest()
        {
            string check = string.Format("http://www.cnn.com/sitemaps/sitemap-index.xml");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(check);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            List<string> disallow = new List<string>();
            string line;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(".xml"))
                    {
                        int index = line.IndexOf("http://");
                        string capture = line.Substring(index);
                        int endIndex = capture.IndexOf("</loc>");
                        disallow.Add(line.Substring(index, endIndex));
                    }
                }
            }

            return disallow.ToArray<string>();
        }
    }
}
