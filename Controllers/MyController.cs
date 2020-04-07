using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index(string key)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<News> newsList = dbContext.Set<News>().ToList();
            dbContext.Dispose();   // 类似于析构函数

            NewsListMessage newsListMessage = new NewsListMessage();
            if (string.IsNullOrEmpty(key))
                newsListMessage.NewsList = newsList;
            else
                newsListMessage.NewsList = newsList.Where(o => o.Keyword.Contains(key)).ToList();
            //newsListMessage.NewsList = newsList;
            //newsListMessage.Message = "新闻管理";       

            return View(newsListMessage);
        }
        public ActionResult Details()
        {
            ViewBag.Message = "我是分部视图";
            
            return PartialView();
        }

        public ActionResult QueryRes(News news)
        {
            ViewBag.Title = news.Title;
            ViewBag.Keyword = news.Keyword;
            return Content("你查询的标题是：" + news.Title + "，关键字是：" + news.Keyword);
        }
    }
}