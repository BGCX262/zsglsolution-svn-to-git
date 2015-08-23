using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Entities
{
    public class FileListEntity
    {
        public List<wjgl_files> Files { get; set; }

        public bool CanAddNewFloder { get; set; }

        public userfloder FloderInfo { get; set; }

        public bool CanDelFolder { get; set; }
    }
}
