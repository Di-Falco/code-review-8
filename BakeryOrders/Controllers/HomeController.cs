using Microsoft.AspNetCore.Mvc;
using BakeryOrders.Models;

namespace BakeryOrders.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}