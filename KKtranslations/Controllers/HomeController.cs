using KKtranslations.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace KKtranslations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string price1, price2, price3, price4;
            //Bulgaria
            if (RegionInfo.CurrentRegion.TwoLetterISORegionName == "BG")
            {
                price1 = Resource.Price1;
                price2 = Resource.Price2;
                price3 = Resource.Price3;
                price4 = Resource.Price4;
            }//check if it is in EU
            else if ("BE,CZ,DK,DE,EE,IE,EL,ES,FR,HR,IT,CY,LV,LT,LU,HU,MT,NL,AT,PL,PT,RO,SI,SK,FI,SE,UK".IndexOf(RegionInfo.CurrentRegion.TwoLetterISORegionName) != -1)
            {
                price1 = Resource.Price1EU;
                price2 = Resource.Price2EU;
                price3 = Resource.Price3EU;
                price4 = Resource.Price4EU;
            }//Rest of the world
            else
            {
                price1 = Resource.Price1;
                price2 = Resource.Price2;
                price3 = Resource.Price3;
                price4 = Resource.Price4;
            }

            ViewData["Price1"] = price1;
            ViewData["Price2"] = price2;
            ViewData["Price3"] = price3;
            ViewData["Price4"] = price4;

            ContactModel model = new ContactModel();
            return View(model);
        }

        [HttpPost]  
        public ActionResult Index(ContactModel model)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(System.Configuration.ConfigurationManager.AppSettings["email"]);
            mail.From = new MailAddress(model.EMail);
            mail.Subject = "Customer request";
            string Body = model.Comments;
            Body += "<br/><br/><br/>";
            Body += model.Name + " phone:" + model.PhoneNumber + " email:" + model.EMail;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("stefchov@gmail.com", "");// Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return Content("Success");
        }
    }
}