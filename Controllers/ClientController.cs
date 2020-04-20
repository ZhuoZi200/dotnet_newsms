using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<News> newsList = dbContext.Set<News>().ToList();
            dbContext.Dispose();

            NewsListMessage newsListMessage = new NewsListMessage();
            newsListMessage.NewsList = newsList;

            return View(newsListMessage);
        }
    }
}