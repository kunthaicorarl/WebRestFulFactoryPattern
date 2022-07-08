using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebRestFulFactoryPattern.App.Applications
{
    
    public class LogAppService : ILogAppService
    {
        private IAuditAppService _auditAppService;
        public LogAppService(IAuditAppService auditAppService)
        {
            _auditAppService = auditAppService;
        }

        public GetBaseResponseData Action(GetBaseRequestInput input)
        {
            var d = JsonConvert.DeserializeObject<GetLogInput>(input.Data);
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(input.Method);
            if (theMethod == null) throw new ApplicationException($"{input.Method} is not registered");
            var data = theMethod.Invoke(this, new object[] { d });
            return (GetBaseResponseData)data;
        }

        public LogDto GetList(GetLogInput input)
        {

            var test = input.Text;
            return new LogDto() {
                Text = "My Dto" + _auditAppService.GetAudits().Text
            };
        }

       
    }
}
