using Assign_16_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Assign_16_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckForm(string fn, string ln, string em, string ps, string cps)
        {
            if (fn == null || ln == null || em == null || ps == null || cps == null )
            {
                return Redirect("Index");
            }
            else if (ps != cps)
            {
                return Redirect("Index");
            }
            else if (ps.Length <= 4)
            {
                return Redirect("Index");
            }
            else
            {
                int count = 0;
                if (em.Length >= 2)
                {
                    foreach (char c in em)
                    {
                        if (c == '@')
                        {
                            count++;
                        }
                        if (count > 1)
                        {
                            return Redirect("Index");
                        }
                    }
                    return Content($"All Set {fn} - {ln}!");
                }
                else
                {
                    return Redirect("Index");
                }
            }
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
