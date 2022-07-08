using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestFulFactoryPattern.App;
using WebRestFulFactoryPattern.App.Applications;

namespace WebRestFulFactoryPattern
{
    public class RegisteredService
    {
         public static Dictionary<string, Tuple<Type,Type>> GetService()
        {
            var r = new Dictionary<string, Tuple<Type, Type>>();
            r.Add(ServiceNameConst.LOG, new Tuple<Type, Type>(typeof(ILogAppService), typeof(LogAppService)));
            r.Add(ServiceNameConst.Audit, new Tuple<Type, Type>(typeof(IAuditAppService), typeof(AuditAppService)));
            return r;
        }
    }
}
