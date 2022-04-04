using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempManager.Models;


namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {

        private TempManagerContext data { get; set; }
        public ValidationController(TempManagerContext ctx) => data = ctx;

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CheckDate(string date)
        {
            var dateTime = DateTime.Parse(date);

            var existing = data.Temps.Where(temp => temp.Date.Equals(dateTime)).FirstOrDefault();

            if(existing == null)
            {
                return Json(true);
            }

            return Json("Date has already existed");
        }
    }
}
