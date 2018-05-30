using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntelektikosProjektas.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace IntelektikosProjektas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Index()
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("select * from test", conn);


            List<Test> list = new List<Test>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Test()
                    {
                        Id = Convert.ToInt32(reader["idtest"])
                    });
                }
            }



            return View(list);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
