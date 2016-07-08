using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;
namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
          public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblUser login)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var user = (from userlist in db.tblUsers
                            where userlist.UserName == login.UserName && userlist.Password == login.Password
                            select new
                            {
                                userlist.UserID,
                                userlist.UserName
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().UserName;
                    Session["UserID"]=user.FirstOrDefault().UserID;
                    return Redirect("/home/welcomepage");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }

        public ActionResult WelcomePage()
        {
            return View();
        }
    }
}
    