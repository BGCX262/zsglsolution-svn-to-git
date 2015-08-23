using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class FsyhGxModel
    {
        public IList<yhgl_users> AllUsers { get; set; }
        public IList<wjgl_files> FileInfo { get; set; }
    }
}
