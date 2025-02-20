using MetodosOrdenacao.Services;

var builder = WebApplication.CreateBuilder(args);

//Add cors
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5500")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(logger =>
{
    logger.AddConsole();
    logger.AddDebug();
    logger.SetMinimumLevel(LogLevel.Information);
});
builder.Services.AddScoped<IBubbleSortService, BubbleSortService>();
builder.Services.AddScoped<IInsertionSortService, InsertionSortService>();
builder.Services.AddScoped<ISelectionSortService, SelectionSortService>();
builder.Services.AddScoped<IQuickSortService, QuickSortService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
