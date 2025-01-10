using ArticleChat.Models;
using ArticleChat.Models.Interfaces;
using ArticleChat.Models.Services;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ArticleChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ArticleChatDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllersWithViews();

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IArticleService, ArticleService>();

            builder.Services.AddAuthentication("MyCookieAuth")
            .AddCookie("MyCookieAuth", options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LogoutPath = "/Account/Logout";
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //{
            //    options.LoginPath = "/Auth/Login";
            //    options.LogoutPath = "/Auth/Logout";
            //});

            //builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error/NotFound");
            app.UseExceptionHandler("/Error/GeneralError");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
