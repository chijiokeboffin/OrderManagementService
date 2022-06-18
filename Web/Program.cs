using Domain.Exceptions;
using Presentation.Controllers;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Serialization;
using Presentation.ActionFilters;
using Web.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

try
{
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var personAssembly = typeof(PersonController).GetTypeInfo().Assembly;
    builder.Services.AddControllers().AddApplicationPart(typeof(OrderController).GetTypeInfo().Assembly);
    builder.Services.AddControllers().AddApplicationPart(personAssembly);
    builder.Services.AddTransient<ErrorHandlerMiddleware>();
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        //customize settings here. For example, change the naming strategy

        options.SerializerSettings.ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy() // new SnakeCaseNamingStrategy() 
        };
    });
    builder.Services.AddScoped<ValidationFilterAttribute>();
    ConfigurationManager configuration = builder.Configuration;
    builder.Services.ConfigureMySqlContext(configuration);
    builder.Services.ConfigureServices();
    builder.Services.ConfigureRepository();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
       
    }
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{

}