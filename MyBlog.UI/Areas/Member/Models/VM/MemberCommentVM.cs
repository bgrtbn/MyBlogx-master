using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Member.Models.VM
{
    public class MemberCommentVM
    {
        public Guid ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}