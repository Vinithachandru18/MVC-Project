using Logistics_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Logistics_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       

        //Login module
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(login_details log)
        {


            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (var con = new SqlConnection(connectionString))
            {



                using (var cmd = new SqlCommand("select dbo.userlogincheck(@username,@pwd)", con))
                {
                    cmd.Parameters.AddWithValue("@username", log.Username);
                    cmd.Parameters.AddWithValue("@pwd", log.Password);


                    con.Open();
                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)
                    {
                        con.Close();
                        string id = log.Username;
                        return RedirectToAction("Index","Log");

                    }
                    else
                    {
                        return RedirectToAction("Index");

                    }
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