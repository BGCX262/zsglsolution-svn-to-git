using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class GxFilesModel
    {
        /// <summary>
        /// 主用户—可查看的共享文件
        /// </summary>
        public IList<ZyhGxFilesEntity> ZyhGxFiles { get; set; }
    }
}
