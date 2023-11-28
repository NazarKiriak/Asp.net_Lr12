using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;




namespace WebApplication14
{
   

    public class HomeController : Controller
        {
            private readonly ApplicationContext db;

            public HomeController(ApplicationContext context)
            {
                db = context;
            }

        public async Task<IActionResult> Index()

		{

            var users = await db.Users.ToListAsync();
	        foreach(var user in users)
            {
                Console.WriteLine($"Iм'я: {user.FirstName}, Прiзвище: {user.LastName}, Вiк: {user.Age}");

			}
			return View("./Views/Index.cshtml", await db.Users.ToListAsync());
           

        }



		public async Task<IActionResult> ViewCompany()

		{
	
			return View("./Views/Company.cshtml", await db.Companies.ToListAsync());


		}



		public IActionResult Create()

        {

            return View("./Views/CreateUser.cshtml");

        }

        [HttpPost]
         public async Task<IActionResult> Create([Bind("FirstName, LastName, Age")] User user)

        {

            db.Users.Add(user);

            await db.SaveChangesAsync();

            return RedirectToAction("Index");

        }

    }
    }
