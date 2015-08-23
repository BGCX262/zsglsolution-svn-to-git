using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class FsyhModel
    {
        /// <summary>
        /// 附属用户信息
        /// </summary>
        public yhgl_fsyh FsyhInfo { get; set; }

        /// <summary>
        /// 附属用户可查看的文件
        /// </summary>
        public IList<FsyhGxFileEntity> FsyhGxInfo { get; set; }
    }
}
