using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Entities
{
    public class FriendEntity
    {
        public yhgl_users YhInfo { get; set; }
        public hygl_group GroupInfo { get; set; }
        public hygl_friend FriendMx { get; set; }
    }
}
