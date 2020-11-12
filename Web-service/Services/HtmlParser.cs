using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web_service.Models;

namespace Web_service.Services
{
    public class HtmlParser
    {
        private static readonly string imgSrcPattern = ".*?<img .*?src=\"(.*?)\"";
        private static readonly string imgAltPattern = ".*?<img .*?alt=\"(.*?)\"";
        
        public static List<Image> GetImages(string html, int imageCount, string url)
        {
            List<Image> images = null;
            try
            {
                var urlAuthority = new Uri(url).GetLeftPart(UriPartial.Authority);
                var imagesSrc = new Regex(imgSrcPattern)
                    .Matches(html)
                    .Take(imageCount)
                    .Select(i => !i.Groups[1].Value.Contains("http") ? urlAuthority + i.Groups[1].Value : i.Groups[1].Value)
                    .ToList();
                var imagesAlt = new Regex(imgAltPattern)
                    .Matches(html)
                    .Take(imageCount)
                    .Select(i => i.Groups[1].Value)
                    .ToList();

                images = Enumerable.Range(0, imagesSrc.Count())
                    .Select(r => new Image()
                    {
                        Src = imagesSrc[r],
                        Alt = imagesAlt[r],
                        Size = long.MinValue
                    })
                    .ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return images ?? new List<Image>();
        }
    }
}
