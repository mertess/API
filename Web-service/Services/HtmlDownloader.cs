using NLog;
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
        private static readonly Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public static string DownloadHtml(string url)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                using StreamReader reader = new StreamReader(response.GetResponseStream());

                while (!reader.EndOfStream)
                    stringBuilder.Append(reader.ReadLine());
            }
            catch (Exception ex) { logger.Warn($"{ex.Message} {ex.InnerException?.Message}"); }
            return stringBuilder.ToString();
        }
    }
}
