using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Entities
{
    public class GxEntity
    {
       public List<string> UserList { get; set; }
       public List<string> FileList { get; set; }
       public List<string> FsyhList { get; set; }

        //比较时使用
       public List<gxgl_zyhgx> ZyhgxMx { get; set; }
       public List<gxgl_fsyhgxb> FsyhgxMx { get; set; }
    }
}
