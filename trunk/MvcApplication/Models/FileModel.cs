using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class FileModel
    {
        public IList<wjgl_files> Files { get; set; }
    }
}
