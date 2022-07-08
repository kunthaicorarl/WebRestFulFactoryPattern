using Microsoft.AspNetCore.Mvc;

namespace WebRestFulFactoryPattern.Controllers
{
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}