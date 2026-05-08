using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Repositories;
using Siemens.Internship2026.GradeBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IGradeRepository, GradeAPIRepository>();
builder.Services.AddScoped<IGradeReader>(sp => sp.GetRequiredService<IGradeRepository>());
builder.Services.AddScoped<IGradeStatisticsService, GradeStatisticsService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ILoggerService, ConsoleLoggerService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
