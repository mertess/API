using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Web_service.Models;

namespace Web_service.Services
{
    public class ImageDownloader
    {
        private static readonly Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public void DownloadImage(Image image)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(image.Src, AppDomain.CurrentDomain.BaseDirectory + "Images/" + image.Src.Substring(image.Src.LastIndexOf('/') + 1));

                FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Images/" + image.Src.Substring(image.Src.LastIndexOf('/') + 1));
                image.Size = fileInfo.Length;
            }
            catch (Exception ex) { logger.Warn($"{ex.Message} {ex.InnerException?.Message}"); }
        }
    }
}
