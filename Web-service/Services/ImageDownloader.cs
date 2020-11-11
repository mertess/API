using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web_service.Models;

namespace Web_service.Services
{
    public class ImageDownloader
    {
        //посмотреть
        public void DownloadImage(string hostUrl, Image image)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(!image.Src.Contains("http") ? hostUrl + image.Src : 
                image.Src, AppDomain.CurrentDomain.BaseDirectory + "Images/" + image.Src.Substring(image.Src.LastIndexOf('/') + 1));
        }
    }
}
