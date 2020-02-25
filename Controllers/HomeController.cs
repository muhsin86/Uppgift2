using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Uppgift2.Models;

namespace Uppgift2.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            var dt = DateTime.Now.ToString("HH:mm:ss");
            HttpContext.Session.SetString("date", dt);
            ViewBag.dateSession = dt;

            ViewData["Message"] = "Det finns många olika varianter av Lorem Ipsum, " +
                                            "men majoriteten av dessa har ändrats på någotvis. " +
                                            " Antingen med inslag av humor, eller med inlägg av ord som knappast ser trovärdiga ut. " +
                                           "Skall man använda långa stycken av Lorem Ipsum bör " +
                                           "man försäkra sig om att det inte gömmer sig något pinsamt mitt i texten. " +
                                           "Lorem Ipsum-generatorer på internet tenderar att repetera Lorem Ipsum-texten " +
                                           "styckvis efter behov, något som gör denna sidan till den första riktiga Lorem " +
                                           "Ipsum-generatorn på internet. Den använder ett ordförråd på över 200 ord, " +
                                           "kombinerat med ett antal meningsbyggnadsstrukturer som tillsamman genererar " +
                                           "Lorem Ipsum som ser ut som en normal mening. Lorem Ipsum genererad på denna " +
                                           "sidan är därför alltid fri från repetitioner, humorinslag, märkliga ordformationer osv.";

            return View();
        }

        public IActionResult About()
        {
            var dt = DateTime.Now.ToString("HH:mm:ss");
            HttpContext.Session.SetString("date", dt);
            ViewBag.dateSession = dt;
            return View();
        }

        [HttpGet]
        public IActionResult Courses()
        {
            var dt = DateTime.Now.ToString("HH:mm:ss");
            HttpContext.Session.SetString("date", dt);
            ViewBag.dateSession = dt;
            var jsonStr = System.IO.File.ReadAllText("courses.json");
            var jsonObj = JsonConvert.DeserializeObject<List<CourseModel>>(jsonStr);
            ViewBag.Courses = jsonObj;
            return View();
        }

        [HttpPost]
        public IActionResult Courses(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                // Läs in befintlig
                var JsonStr = System.IO.File.ReadAllText("courses.json");
                var JsonObj = JsonConvert.DeserializeObject<List<CourseModel>>(JsonStr);
                JsonObj.Add(model);
                // Konvertera till JSON-sträng
                // Lagra 
                System.IO.File.WriteAllText("courses.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                ModelState.Clear();


            }
            return View();
        }

        public IActionResult Calculate()
        {
            var dt = DateTime.Now.ToString("HH:mm:ss");
            HttpContext.Session.SetString("date", dt);
            ViewBag.dateSession = dt;

            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["txtFirst"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["txtSecond"].ToString());
            int result = num1 + num2;
            ViewBag.SumResult = result.ToString();
            return View("Calculate");
        }
    }
}
