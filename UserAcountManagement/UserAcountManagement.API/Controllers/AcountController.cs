using Microsoft.AspNetCore.Mvc;

namespace UserAcountManagement.API.Controllers;

public class AcountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
