using Autofac;
using Autofac.Extensions.DependencyInjection;
using FirstCoreMVCWebApplication;
using FirstCoreMVCWebApplication.Caching.Repository;
using FirstCoreMVCWebApplication.Caching.Services;
using FirstCoreMVCWebApplication.Data;
using FirstCoreMVCWebApplication.Models;
using FirstCoreMVCWebApplication.Models.Fluent_Validation;
using FirstCoreMVCWebApplication.Models.ServiceCollectionDI;
using FirstCoreMVCWebApplication.Models.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using StackExchange.Redis;

#region Bootstrap Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
             .ReadFrom.Configuration(configuration)
             .CreateBootstrapLogger();
#endregion

try
{
    Log.Information("Application starting....");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    #region Autofac Configure
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new WebModule());
    });
    #endregion

    #region Serilog Configure
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration)
    );
    #endregion

    builder.Services.AddScoped<IStudentRepository, StudentRepository>();

    #region Service Collection DI
    builder.Services.AddKeyedScoped<IItem, Item1>("Config1");
    builder.Services.AddKeyedScoped<IItem, Item2>("Config2");
    #endregion

    #region RateLimiter
    builder.Services.AddRateLimiter(options =>
    {
        options.AddFixedWindowLimiter("FixedWindowPolicy", opt =>
        {
            opt.Window = TimeSpan.FromSeconds(5);
            opt.PermitLimit = 5;
            opt.QueueLimit = 10;
            opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        }).RejectionStatusCode = 429;
    });

    builder.Services.AddRateLimiter(options =>
    {
        options.AddTokenBucketLimiter("TokenBucketPolicy", opt =>
        {
            opt.TokenLimit = 4;
            opt.QueueLimit = 2;
            opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
            opt.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
            opt.TokensPerPeriod = 4;
            opt.AutoReplenishment = true;
        }).RejectionStatusCode = 429;
    });
    #endregion

    #region Validator Configuration
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    builder.Services.AddTransient<IValidator<RegistrationModel>, RegistrationValidator>();
    #endregion

    #region Caching Configuration
    builder.Services.AddMemoryCache();
    builder.Services.AddScoped<LocalRepository>();
    builder.Services.AddSingleton<CacheManager>();
    #endregion

    #region Radis cache
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration["RedisCacheOptions:Configuration"];
        options.InstanceName = builder.Configuration["RedisCacheOptions:InstanceName"];
    });
    builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>

    ConnectionMultiplexer.Connect(builder.Configuration["RedisCacheOptions:Configuration"]));

    #endregion

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseRateLimiter();

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
    Log.Information("Application running....");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application crashed");
}
finally
{
    Log.CloseAndFlush();
}