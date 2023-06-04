using GitHub;
using Scientist.Publishers.Serilog;
using ScientistApp.Services;
using ScientistApp.Services.NoSql;
using ScientistApp.Services.Science;
using ScientistApp.Services.SqlRepository;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsersRepository, ScienceRepository>();
builder.Services.AddScoped<NoSqlUsersRepository>();
builder.Services.AddScoped<SqlUsersRepository>();

builder.Services.AddTransient<IScientist, GitHub.Scientist>();
builder.Services.AddTransient<IResultPublisher>(_ =>
    new FireAndForgetResultPublisher(new SerilogResultPublisher()));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
Log.CloseAndFlush();
