using DotnetConfiguration;
using DotnetConfiguration.CustomConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configurationManager = builder.Configuration as IConfigurationManager;
configurationManager.Add(new PostgreConfigurationSource());
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(nameof(SmtpOptions)));
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
await app.RunAsync();