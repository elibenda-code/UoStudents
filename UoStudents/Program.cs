using Microsoft.EntityFrameworkCore;
using UoStudents.Data;
using UoStudents.Services;
using UoStudents.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UopenDbContext>(options =>
    options.UseSqlite("Data Source=students.db"));

builder.Services.AddScoped<IStudents, StudentService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error != null)
        {
            await context.Response.WriteAsJsonAsync(new { message = "Internal Server Error", detail = error.Error.Message });
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();