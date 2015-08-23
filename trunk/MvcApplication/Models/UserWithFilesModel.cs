using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class UserWithFilesModel
    {
        public List<UserWithFilesEntity> UserWithFiles { get; set; }
    }
}
