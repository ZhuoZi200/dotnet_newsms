using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Regis(UserInfo userInfo)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            dbContext.Set<UserInfo>().Add(userInfo);
            dbContext.SaveChanges();
            dbContext.Dispose();   // 类似于析构函数
            return View("Index");
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
    }
}