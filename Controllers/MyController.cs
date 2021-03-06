﻿using System.Collections.Generic;
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
        public ActionResult Index(QueryModel qmodel)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<News> newsList = dbContext.Set<News>().ToList();
            dbContext.Dispose();   // 类似于析构函数

            NewsListMessage newsListMessage = new NewsListMessage();
            if (string.IsNullOrEmpty(qmodel.key))
                newsListMessage.NewsList = newsList;
            else
                newsListMessage.NewsList = newsList.Where(o => o.Keyword.Contains(qmodel.key)).ToList();     

            return View(newsListMessage);
        }
        [HttpPost]
        public ActionResult Index(LoginModel loginmodel)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<News> newsList = dbContext.Set<News>().ToList();
            List<UserInfo> userInfoList = dbContext.Set<UserInfo>().ToList();
            dbContext.Dispose();   // 类似于析构函数

            NewsListMessage newsListMessage = new NewsListMessage();
            newsListMessage.NewsList = newsList;
            newsListMessage.CurrentUserName = loginmodel.iusername;

            ViewBag.NewsList = newsList;
            ViewBag.CurrentUserName = loginmodel.iusername;

            foreach (var item in userInfoList)
            {
                if(item.Nickname == loginmodel.iusername && item.Password == loginmodel.ipassword)
                {
                    return View(newsListMessage);
                } 
            }
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult Add()
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<NewsType> newsTypeList = dbContext.Set<NewsType>().ToList();
            dbContext.Dispose();   // 类似于析构函数
            ViewBag.newsTypeList = newsTypeList;

            return View();
        }
        [HttpPost]
        public ActionResult Add(News news)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            dbContext.Set<News>().Add(news);
            dbContext.SaveChanges();
            dbContext.Dispose();   // 类似于析构函数
            return View();
        }
        public ActionResult Modify(ModifyModel modifymodel)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<News> newsList = dbContext.Set<News>().ToList();
            newsList[modifymodel.Index].Title = modifymodel.Title;
            newsList[modifymodel.Index].Author = modifymodel.Author;
            newsList[modifymodel.Index].Keyword = modifymodel.Keyword;
            newsList[modifymodel.Index].Type = modifymodel.Type;
            dbContext.SaveChanges();
            dbContext.Dispose();

            NewsListMessage newsListMessage = new NewsListMessage();
            newsListMessage.NewsList = newsList;

            return View("~/Views/My/Index.cshtml", newsListMessage);
        }
        public ActionResult Delete(int Index)
        {
            DbContext dbContext = new DbContext("NEWSEntities");
            List<News> newsList = dbContext.Set<News>().ToList();
            //newsList.Remove(newsList[Index]);
            //News news = dbContext.Set<News>().Find(Index);
            dbContext.Set<News>().Remove(newsList[Index]);
            dbContext.SaveChanges();

            NewsListMessage newsListMessage = new NewsListMessage();
            newsListMessage.NewsList = newsList;
            newsList = dbContext.Set<News>().ToList();
            dbContext.Dispose();

            return View("~/Views/My/Index.cshtml", newsListMessage);
        }
        public ActionResult Details()
        {
            ViewBag.Message = "我是分部视图";

            return PartialView();
        }
    }
}