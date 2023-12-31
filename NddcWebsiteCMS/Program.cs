using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;
using WebsiteCMSLibrary.Data.HomePage.Updates;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Services.AWSStorageService;
using WebsiteCMSLibrary.Services.AzureStorageService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<INewsData, SQLNews>();
//builder.Services.AddTransient<IAzureStorage, AzureStorage>();
builder.Services.AddTransient<IAzureStorage, AWSStorage>();
builder.Services.AddTransient<IUpdatesData, SqlUpdates>();
builder.Services.AddTransient<IPhotoSpeakData, SqlPhotoSpeak>();
builder.Services.AddTransient<IHelperData, Utility>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
