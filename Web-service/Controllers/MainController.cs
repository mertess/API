using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_service.Models;
using Web_service.Services;

namespace Web_service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public List<HostImages> GetImages(string url, int imageCount)
        {
            var images = HtmlParser.GetImages(HtmlDownloader.DownloadHtml(url), imageCount, url);
            var hostsImages = images
                .GroupBy(image => new Uri(image.Src).Host)
                .Select(imgGroup => new HostImages()
                {
                    Host = imgGroup.Key,
                    Images = imgGroup.ToList()
                })
                .ToList();
            //ImageDownloader imageDownloader = new ImageDownloader();
            //imageDownloader.DownloadImage(images[0]);
            return hostsImages;
        }
    } 
}