using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public class Startup
    {
        // Необязательный метод ConfigureServices() регистрирует сервисы, которые используются приложением
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Обязательный метод Configure устанавливает, как приложение будет обрабатывать запрос
        // Объект IApplicationBuilder является обязательным параметром для метода Configure
        public void Configure(IApplicationBuilder app)
        {

            app.UseToken("12345");

            app.Map("/index", Index);
            app.Map("/about", About);

            int x = 2;
            app.Use(async (context, next) =>
            {
                x = x * 2;      // 2 * 2 = 4
                await next.Invoke();    // вызов app.Run
                x = x * 2;      // 8 * 2 = 16
                await context.Response.WriteAsync($"Result: {x}");
            });

            app.Run(async (context) =>
            {
                x = x * 2;  //  4 * 2 = 8
                await Task.FromResult(0);
            });
        }

        // Объект IApplicationBuilder является обязательным параметром для метода Configure
        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        // Объект IApplicationBuilder является обязательным параметром для метода Configure
        private static void About(IApplicationBuilder app)
        {
            // Обработка запроса - получаем констекст запроса в виде объекта context
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("About");
            });
        }
            
        }

}
