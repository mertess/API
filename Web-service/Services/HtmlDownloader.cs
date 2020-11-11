using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web_service.Services
{
    public class HtmlDownloader
    {
        public static string DownloadHtml(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            using StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder stringBuilder = new StringBuilder();
            while (!reader.EndOfStream)
                stringBuilder.Append(reader.ReadLine());

            return stringBuilder.ToString();
        }
    }
}
