using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Entities
{
    public class UserWithFilesEntity
    {
        public yhgl_users User { get; set; }

        public List<wjgl_files> Files { get; set; }
    }
}
