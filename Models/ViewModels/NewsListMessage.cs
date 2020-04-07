using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class NewsListMessage
    {
        public List<News> NewsList { get; set; }
        public string Message { get; set; }
    }
}