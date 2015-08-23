using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MvcApplication.Entities;

namespace MvcApplication.DAO
{
    public class AvatarDAO
    {
        UserDataContext userDB = new UserDataContext();
        public void DelAvatar(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void ChangeAvatar(string path,int userId)
        {
            var user = (from u in userDB.yhgl_users
                        where u.user_id == userId
                        select u).First();
            user.user_avatar = path;
            userDB.SubmitChanges();
            
        }
    }
}
