using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core Demo App";
            List<Person> people = new List<Person>()
            {
            new Person(){ Name = "Joe", DateOfBirth = DateTime.Parse("2000-05-06"), GenderType = Person.Gender.Male},
            new Person(){ Name = "Jane", DateOfBirth = DateTime.Parse("2000-05-06"), GenderType = Person.Gender.Female},
            new Person(){ Name = "JaneJoe", DateOfBirth = DateTime.Parse("2000-05-06"), GenderType = Person.Gender.Other}
            };

            ViewData["people"] = people;
            return View();  // Views/Home/Index.cshtml
            //return View("abc"); // Views/Home/abc.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }
    }
}
