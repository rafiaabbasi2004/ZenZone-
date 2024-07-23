using Microsoft.Extensions.DependencyInjection;
using testdatabase;
using testdatabase.DataLayer;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Register your data access service
builder.Services.AddSingleton<DatabaseService>();
builder.Services.AddSingleton<TrailService>();
builder.Services.AddSingleton<UserState>();
builder.Services.AddSingleton<MindfulnessExercise>();
builder.Services.AddSingleton<MindfulnessExerciseService>();
builder.Services.AddSingleton<MeditationStateService>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();




// Add your connection string here
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped(_ => new DataAccess(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}






// Configure the HTTP request pipeline and run the app
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
