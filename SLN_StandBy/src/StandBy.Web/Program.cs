
using StandBy.Web.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder =>
//        {
//            builder
//            .AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials();
//        });
//});

builder.Services.RegisterServices(builder.Configuration);


builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddCors();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityConfiguration();






var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseIdentityConfiguration();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();






app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
