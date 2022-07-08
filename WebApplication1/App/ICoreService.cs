using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestFulFactoryPattern.App.Applications;

namespace WebRestFulFactoryPattern.App
{
     public interface ICoreService
    {
        GetBaseResponseData Action(GetBaseRequestInput input);
    }
}
