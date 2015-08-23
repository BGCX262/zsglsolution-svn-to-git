using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class ZyhGxModel
    {
        public IList<yhgl_users> AllUsers { get; set; }
        public IList<wjgl_files> FileInfo { get; set; }
        public IList<yhgl_fsyh> FsyhInfo { get; set; }
    }
}
