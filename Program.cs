using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Repositories;
using Siemens.Internship2026.GradeBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemReader>(sp => sp.GetRequiredService<IItemRepository>());
builder.Services.AddScoped<IItemWriter>(sp => sp.GetRequiredService<IItemRepository>());
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ILoggerService, ConsoleLoggerService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
