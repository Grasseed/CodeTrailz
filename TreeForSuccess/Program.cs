using Dapper;
using TreeForSuccess;
using Microsoft.Extensions.Configuration;
using TreeForSuccess.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); // 啟用所有控制器
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperServices>(); // 讀取資料庫連接字串
builder.Services.AddTransient<GoalModel>();
builder.Services.AddTransient<UserModel>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); //使用控制器

app.Run();
