using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Web_service
{
    [DataContract]
    public class Test
    {
        [DataMember]
        public string TestStr { get; set; }
    }
}
