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
using System.Net.Mail;
using System.Net;
using clubweb.shared.models.contacts;

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
            return View();
        }

        /// <summary>
        /// Author: Albert Guerrero from Er-Er Tech - Able to send email using SMTP server
        /// Note: This is only for gmail 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Contact(Contact model)
        {
            try
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("EMAILHERE@gmail.com")); //-- Put your email gmail email address
                message.From = new MailAddress("EMAILHERE@gmail.com"); //-- Put your email gmail email address
                message.Subject = "N3UG.ClubWeb Question";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "EMAILHERE@gmail.com", //-- Put your email gmail email address
                        Password = "PASSWORDHERE" //-- Put your email gmail Password
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    //Success
                    ViewBag.Status = true;
                }
            }
            //Fails
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";
            }

            //return model to Contact.cshtml
            return View(model);
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
