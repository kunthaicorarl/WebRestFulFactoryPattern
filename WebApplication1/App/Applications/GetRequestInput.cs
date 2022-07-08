using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestFulFactoryPattern.App.Applications
{
    public class GetRequestInput
    {
         public string Module { get; set; }
         public string Method { get; set; }
         public GetBaseRequestInput Data { get; set; }
    }
}
