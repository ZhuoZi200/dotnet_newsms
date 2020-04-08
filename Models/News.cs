//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public string Keyword { get; set; }
        public string Introduce { get; set; }
        public string Contents { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<int> Hits { get; set; }
        public Nullable<int> isRec { get; set; }
        public Nullable<int> isTop { get; set; }
        public Nullable<int> isHead { get; set; }
        public Nullable<int> CheckStatus { get; set; }
        public string CheckUserName { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public string CheckMeno { get; set; }
        public Nullable<long> Type { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }
    }
}
