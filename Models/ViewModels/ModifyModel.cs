using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class ModifyModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keyword { get; set; }
        public long Type { get; set; }
        public int Index { get; set; }
    }
}