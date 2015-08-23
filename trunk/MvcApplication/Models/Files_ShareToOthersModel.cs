using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;

namespace MvcApplication.Models
{
    public class Files_ShareToOthersModel
    {
        public List<Files_ShareToZyhEntity> Files_ShareToZyhEntities { get; set; }
        public List<Files_ShareToFsyhEntity> Files_ShareToFsyhEntities { get; set; }
    }
}
