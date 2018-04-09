using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clubweb.client.Models;
using clubweb.shared.models.user;
using System.Net.Http;
using RestSharp;

namespace clubweb.client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult Users()
        {
            var users = new List<userViewModel>();

            // call server api to get list of users and
            // pass it to the view
            var client = new RestClient("http://localhost:52727/api");
            var request = new RestRequest("user", Method.GET);

            var response = client.Execute<List<userViewModel>>(request);

            var _users = response.Data;
            if (_users != null) {
                users = _users;
            }

            return View(users);
        }
    }
}
