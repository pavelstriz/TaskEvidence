using Chatty.Hubs;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using TaskEvidence.Data;
using TaskEvidence.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("No connection string in configuration!");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EvidenceDbContext>((DbContextOptionsBuilder options) => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IChecklistService, ChecklistService>();
builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts => {
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});
var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapHub<ChatHub>("/chathub");
app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
