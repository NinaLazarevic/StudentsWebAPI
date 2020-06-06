using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsWebAPI.Data.Models;
using StudentsWebAPI.Web.Utility;

namespace StudentsWebAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<StudentModel> students = APIAccess.GetStudentsFromAPI("https://localhost:44311/api/", "students");

            if(students == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(students);
        }
    }
}