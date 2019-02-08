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
        //Создаем конструктор 
        IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }
        // Необязательный метод ConfigureServices() регистрирует сервисы, которые используются приложением
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Обязательный метод Configure устанавливает, как приложение будет обрабатывать запрос
        // Объект IApplicationBuilder является обязательным параметром для метода Configure
        public void Configure(IApplicationBuilder app)
        {
            // Обработка запроса - получаем констекст запроса в виде объекта context
            app.Run(async (context) =>
            {
                // В браузер будет выводиться название приложения, которое хранится в свойстве _env.ApplicationName
                await context.Response.WriteAsync(_env.ApplicationName);
            });
        }
    }
}
