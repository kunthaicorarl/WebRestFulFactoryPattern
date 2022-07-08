using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebRestFulFactoryPattern.App;
using WebRestFulFactoryPattern.App.Applications;
using WebRestFulFactoryPattern.App.Constants;
using WebRestFulFactoryPattern.Models;

namespace WebRestFulFactoryPattern.Controllers
{
    [Authorize]
    public class RestFulApiController : Controller
    {
        private readonly ILogger<RestFulApiController> _logger;
        public RestFulApiController(ILogger<RestFulApiController> logger)
        {
            _logger = logger;
        }
        public async Task<JsonResult> Api(IAuthorizationService authorizationService,GetBaseRequestInput input)
        {
            if (input.Service == null || input.Method == null) return null;
            var permissonString = Permissions.GeneratePermissionsForMethod($"{input.Service.ToLower()}s", input.Method.Trim());
            var authizied = await authorizationService.AuthorizeAsync(User, permissonString);
            if(!authizied.Succeeded)
            {
                _logger.LogCritical($"{input.Service} No Permission");
                return Json($"{input.Service} No Permission");
            }
            var services = this.HttpContext.RequestServices;
            return await Task.Run(() =>
            {
                var data = RegisteredService.GetService().ContainsKey(input.Service) ? RegisteredService.GetService()[input.Service] :null;
                if(data!=null)
                {
                    var result = (ICoreService)services.GetService(data.Item1);
                    var dta = result.Action(input);
                    return Json(JsonConvert.SerializeObject(dta));
                }
                _logger.LogError($"{input.Service} is not registered");
                return Json($"{input.Service} is not registered");

            });
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
