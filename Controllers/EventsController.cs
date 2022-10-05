using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private Dictionary<string, string> Events = new Dictionary<string, string>();
        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = Events;
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string descript)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(descript))
            {
                return View("/Events");
            }
            else
            {
                Events.Add(name, descript);
                return Redirect("/Events");
            }
        }
    }
}
