using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Hubs;
using Microsoft.Extensions.DependencyInjection;
using VoteFCSoccer.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcVoteCandidatContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcVoteCandidatContext") ?? throw new InvalidOperationException("Connection string 'MvcVoteCandidatContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapHub<VoteHub>("/VoteHub");
    app.MapHub<CandidatHub>("/CandidatHub");
    app.MapHub<LibelleVoteHub>("/LibelleVoteHub");

app.Run();