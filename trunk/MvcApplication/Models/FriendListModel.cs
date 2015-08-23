using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class FriendListModel
    {
        /// <summary>
        /// 好友分组
        /// </summary>
        public IList<hygl_group> FriendGroups { get; set; }

        /// <summary>
        /// 好友明细
        /// </summary>
        public IList<FriendEntity> FriendMx { get; set; }

        /// <summary>
        /// 附属用户明细
        /// </summary>
        public IList<yhgl_fsyh> FsyhMx { get; set; }

        /// <summary>
        /// 管理员没有附属用户
        /// </summary>
        public Boolean IsAdmin { get; set; }
    }
}
