using Hangfire.Dashboard;

namespace TuApp.Infrastructure.Services;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        // Solo permitir a usuarios autenticados con rol de administrador
        return httpContext.User.Identity?.IsAuthenticated == true 
               && httpContext.User.IsInRole("Administrador");
    }
}