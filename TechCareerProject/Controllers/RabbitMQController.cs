using Microsoft.AspNetCore.Mvc;

namespace TechCareerProject.Controllers
{
    public class RabbitMQController : Controller
    {


        public static readonly string queueSendForward = "send-forward-queue";
        public static readonly string queueSendBack = "send-back-queue";
        public static readonly string exchangeDocument = "mail-exchange";



        public IActionResult Index()
        {
            return View();
        }
    }
}
