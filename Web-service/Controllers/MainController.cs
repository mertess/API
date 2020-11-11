using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
        public string GetImages(string url)
        {
            var images = HtmlParser.GetImages(HtmlDownloader.DownloadHtml(url), 10);
            var urlAuthority = new Uri(url).GetLeftPart(UriPartial.Authority);
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.DownloadImage(urlAuthority, images[0]);
            return HtmlDownloader.DownloadHtml(url);
        }
    } 
}