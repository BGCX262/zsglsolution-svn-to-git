using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class UserModel
    {

        /// <summary>
        /// 主用户—可查看的共享文件
        /// </summary>
        public IList<ZyhGxFilesEntity> ZyhGxFiles { get; set; }

        /// <summary>
        /// 上传的文件
        /// </summary>
        public IList<wjgl_files> Files { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public yhgl_users UserInfo { get; set; }

        /// <summary>
        /// 附属用户明细
        /// </summary>
        public IList<yhgl_fsyh> FsyhMx { get; set; }

        /// <summary>
        /// 好友明细
        /// </summary>
        public IList<FriendEntity> FriendMx { get; set; }

        /// <summary>
        /// 用户自己添加的文件夹
        /// </summary>
        public IList<userfloder> UserFloders { get; set; }

        /// <summary>
        /// 好友分组
        /// </summary>
        public IList<hygl_group> FriendGroups { get; set; }

        /// <summary>
        /// 收到的站内信
        /// </summary>
        public List<ZnxEntity> ZnxMx { get; set; }
    }
}
