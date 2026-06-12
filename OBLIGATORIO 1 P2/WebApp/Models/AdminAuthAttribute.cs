using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Models
{
    public class AdminAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? rol = context.HttpContext.Session.GetString("UsuarioRol");
            if (rol != "ADMIN")
            {
                context.Result = new RedirectToActionResult("Login", "Anonimo", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
