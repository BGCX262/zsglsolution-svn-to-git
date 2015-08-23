using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    /// <summary>
    /// 一组（多个）用户模型
    /// </summary>
    public class UsersModel
    {
        public List<yhgl_users> Users { get; set; }
    }
}
