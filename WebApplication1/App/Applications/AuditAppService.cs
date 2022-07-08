using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestFulFactoryPattern.App.Applications
{
    public class AuditAppService : IAuditAppService
    {
        public GetBaseResponseData Action(GetBaseRequestInput input)
        {
            if (input.Method == "GetAudits")
                return this.GetAudits();

            return null;
        }

        public GetAuditOutput GetAudits()
        {
            return new GetAuditOutput() {
                Text = "Audited"
            };
        }
    }
}
