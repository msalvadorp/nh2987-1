using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiPersona.Helpers.Filters
{
    public class AutorizaFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string nombreController = (string)context.RouteData.Values["Controller"];
            string nombreAccion = (string)context.RouteData.Values["Action"];

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
             
            base.OnActionExecuted(context);
        }
    }
}
