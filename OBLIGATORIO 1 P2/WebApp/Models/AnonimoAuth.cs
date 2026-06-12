using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Models
{
    public class AnonimoAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? rol = context.HttpContext.Session.GetString("UsuarioRol");

            // Si ya hay un rol en la sesión, significa que el usuario YA está logueado
            if (!string.IsNullOrEmpty(rol))
            {
                if (rol == "ADMIN")
                {
                    // Si es admin, lo mandamos a su Index
                    context.Result = new RedirectToActionResult("Index", "Administrador", null);
                }
                else if (rol == "OPERADOR")
                {
                    // Si es operador, lo mandamos a sus activos
                    context.Result = new RedirectToActionResult("MisActivos", "Operador", null);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
