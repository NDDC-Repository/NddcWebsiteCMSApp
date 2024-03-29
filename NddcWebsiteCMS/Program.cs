
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Data.HomePage.Announcement;
using WebsiteCMSLibrary.Data.HomePage.Organization;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;
using WebsiteCMSLibrary.Data.HomePage.Publications;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;
using WebsiteCMSLibrary.Data.HomePage.Updates;
using WebsiteCMSLibrary.Data.HomePage.Videos;
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
builder.Services.AddTransient<IVideoData, SqlVideos>();
builder.Services.AddTransient<IPublicationsData, SqlPublications>();
builder.Services.AddTransient<ITendersData, SqlTenders>();
builder.Services.AddTransient<IAnnouncmentData, SQLAnnouncment>();
builder.Services.AddTransient<IOrganizationData, SQLOrganization>();
builder.Services.AddTransient<ITestimonialsData, SQLTestimonials>();
builder.Services.AddTransient<ISightsAndIconsData, SQLSightsAndIcons>();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureADB2C"));

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to 
    // the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages(options => {
    options.Conventions.AllowAnonymousToPage("/Index");
})
.AddMvcOptions(options => { })
.AddMicrosoftIdentityUI();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
