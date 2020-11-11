using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Web_service.Models
{
    public class HostImages
    {
        public string Host { get; set; }
        public List<Image> Images { get; set; }
    }
}
