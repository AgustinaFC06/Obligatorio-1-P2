using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Models
{
    public class OperadorAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? rol = context.HttpContext.Session.GetString("UsuarioRol");
            if (rol != "OPERADOR")
            {
                context.Result = new RedirectToActionResult("Login", "Anonimo", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
