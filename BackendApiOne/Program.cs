var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/getslackname", () =>
{
    var username = new SlackUser
    {
        SlackUserName = "9000Years",
        Age = 99,
        Backend = true,
        Bio = "Always something great about me😃"
    };

    return username;
})
.WithName("GetSlackName");

app.Run();

internal record SlackUser()
{
    public string SlackUserName { get; set; }
    public bool Backend { get; set; }
    public int Age { get; set; }
    public string Bio { get; set; }
}