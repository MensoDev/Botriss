using EchoBotriss.EchoBot.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//BotrissServices
builder.Services.AddBotrissServices();

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin();
            corsPolicyBuilder.AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseWebSockets();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();