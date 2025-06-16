
using Hangfire;
using TuApp.API.Configurations;
using TuApp.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerWithJwt();

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty;
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new Hangfire.Dashboard.LocalRequestsOnlyAuthorizationFilter() }
});

using (var scope = app.Services.CreateScope())
{
    HangfireJobsRegistrar.RegisterJobs(scope.ServiceProvider);
}

app.MapHangfireDashboard();
app.MapControllers();
app.Run();
