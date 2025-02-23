using FluentValidation;
using System.Reflection;
using SignalR.WebApi.Hubs;
using SignalR.BusinessLayer.Container;
using SignalR.DataAccessLayer.Concrete;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using FluentValidation.AspNetCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ContainerDependencies();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();

builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/SignalRHub");

app.Run();
