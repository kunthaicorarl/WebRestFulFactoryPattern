using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestFulFactoryPattern.App.Applications
{
    public class GetLogInput: GetBaseRequestData
    {
         public string Text { get; set; }
    }
}
