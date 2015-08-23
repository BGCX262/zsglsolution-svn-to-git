using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Entities
{
    public class YjmxWithFilesEntity
    {
        public yjgl_yjmx Yjmx { get; set; }
        public List<wjgl_files> Files { get; set; }
    }
}
