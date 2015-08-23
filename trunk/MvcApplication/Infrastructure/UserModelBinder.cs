using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Infrastructure
{
    public class UserModelBinder : IModelBinder
    {
        private const string CartSessionKey = "_usermodel";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.Model != null)
                throw new InvalidOperationException("Cannot update instances");

            // Return the cart from Session[] (creating it first if necessary)
            UserModel user = (UserModel)controllerContext.HttpContext.Session[CartSessionKey];
            if (user == null)
            {
                user = new UserModel();
                controllerContext.HttpContext.Session[CartSessionKey] = user;
            }
            return user;
        }
    }
}
