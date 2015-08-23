using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Infrastructure
{
    public class FsyhModelBinder : IModelBinder
    {
        private const string CartSessionKey = "_fsyhmodel";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.Model != null)
                throw new InvalidOperationException("Cannot update instances");

            // Return the cart from Session[] (creating it first if necessary)
            FsyhModel fsyh = (FsyhModel)controllerContext.HttpContext.Session[CartSessionKey];
            if (fsyh == null)
            {
                fsyh = new FsyhModel();
                controllerContext.HttpContext.Session[CartSessionKey] = fsyh;
            }
            return fsyh;
        }
    }
}
