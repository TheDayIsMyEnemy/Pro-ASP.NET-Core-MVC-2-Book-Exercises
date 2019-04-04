using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcModels.Models
{
    public class HeaderModel
    {
        [FromHeader]
        public string Accept { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string AcceptLanguage { get; set; }

        // using the name property on the attribute to specify header names that cannot be expressed as C# parameter names
        [FromHeader(Name = "Accept-Encoding")] 
        public string AcceptEncoding { get; set; }
    }
}
