var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseHttpsRedirection(); 
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapFallbackToFile("index.html"); 
app.MapGet("/api/TestFile", ()=>
{ 
    string? firstfile = Directory.GetFiles("Resources\\TestFile\\").FirstOrDefault(); 
    return firstfile is not null
           ? Results.Stream(new FileStream(firstfile, FileMode.Open), "application/octet-stream")
           : Results.NotFound();
});
 
app.Run();
