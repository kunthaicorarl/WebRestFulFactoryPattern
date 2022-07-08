using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestFulFactoryPattern.App.Applications
{
    public class GetBaseRequestInput
    {

         public string Service { get; set; }
         public string Method { get; set; }
         public string Data { get; set; }
    }
}
