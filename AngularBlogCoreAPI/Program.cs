using AngularBlogCoreAPI.Controllers;
using AngularBlogCoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//AddCors API with Angular

builder.Services.AddControllers();
builder.Services.AddDbContext<AngularBlogDBContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AngularBlogDBContext)).GetName().Name);
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(y => {
        y.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CorsMiddleware
app.UseCors();

//StaticFileMiddleWare //document , image , pdf vs.
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
