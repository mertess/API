using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web_service.Models;
using Web_service.Services;

namespace Web_service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public List<HostImages> GetImages(string url, int threadCount, int imageCount)
        {
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(1));

            var images = HtmlParser.GetImages(HtmlDownloader.DownloadHtml(url), imageCount, url);
            try
            {
                Parallel.ForEach(images, new ParallelOptions() { MaxDegreeOfParallelism = threadCount, CancellationToken = cancellationTokenSource.Token }, (image) =>
                {
                    new ImageDownloader().DownloadImage(image);
                });
            }
            catch { 
                //operation cancelled exception// 
            }

            var hostsImages = images
                .Where(img => img.Size != long.MinValue)
                .GroupBy(image => new Uri(image.Src).Host)
                .Select(imgGroup => new HostImages()
                {
                    Host = imgGroup.Key,
                    Images = imgGroup.ToList()
                })
                .ToList();

            Response.Headers.Add("Operation-result", $"Downloaded {images.Count(img => img.Size != long.MinValue)}/{imageCount} images");
            return hostsImages;
        }
    }
}