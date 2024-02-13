using Microsoft.EntityFrameworkCore;
using SongListApi.Data; // Anpassa detta till ditt projekt
using SongListApi.Models; // Anpassa detta till ditt projekt

var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster i containern.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Konfigurera HTTP-request-pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed the database
SeedDatabase(app);

app.Run();

void SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();

        // Kontrollera och skapa kategorier först
        if (!dbContext.Categories.Any())
        {
            dbContext.Categories.AddRange(
                new Category { Name = "Metal" },
                new Category { Name = "Rock" }
            );
            dbContext.SaveChanges();
        }

        // Kontrollera och skapa låtar
        if (!dbContext.Songs.Any())
        {
            var metalCategory = dbContext.Categories.FirstOrDefault(c => c.Name == "Metal");
            var rockCategory = dbContext.Categories.FirstOrDefault(c => c.Name == "Rock");

            dbContext.Songs.AddRange(
                new Song
                {
                    Artist = "Metallica",
                    Title = "Master of Puppets",
                    Length = 515,
                    Category = metalCategory
                },
                new Song
                {
                    Artist = "Led Zeppelin",
                    Title = "Stairway to Heaven",
                    Length = 482,
                    Category = rockCategory
                }
            );
            dbContext.SaveChanges();
        }
    }
}
