using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class FileOwned
    {
        public IList<wjgl_files> Files { get; set; }

        public IList<ZyhGxFilesEntity> ZyhGxFiles { get; set; }
    }
}
