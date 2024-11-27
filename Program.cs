using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Hubs;
using Microsoft.Extensions.DependencyInjection;
using VoteFCSoccer.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcVoteCandidatContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcVoteCandidatContext") ?? throw new InvalidOperationException("Connection string 'MvcVoteCandidatContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//SignalR-------------------
builder.Services.AddSignalR();
//SignalR-------------------


builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//Swagger OpenApi----------------------------

builder.Services.AddOpenApiDocument();
//Swagger------------------------------------


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //SwaggerOpenApi-------------------
    app.UseOpenApi();
    app.UseSwaggerUi();
    //OpenAPI--------------------------
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapHub<VoteHub>("/voteHub");
    app.MapHub<CandidatHub>("/candidatHub");
    app.MapHub<LibelleVoteHub>("/libelleVoteHub");

app.Run();