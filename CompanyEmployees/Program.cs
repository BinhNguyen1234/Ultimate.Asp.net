
using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCor();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

#if DEBUG
#elif RELEASE
#endif
// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = ForwardedHeaders.All
});
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();
  

app.MapControllers();

app.Run();