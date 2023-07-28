using Microsoft.AspNetCore.Mvc;

namespace HotelServer.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
