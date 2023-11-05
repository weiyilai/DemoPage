using DemoPage.Repository;
using DemoPage.Service;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddRepository(builder.Configuration)
    .AddService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    InitializeDatabase();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void InitializeDatabase()
{
    using (var db = new SqliteConnection($"Filename=demopage.db"))
    {
        db.Open();

        string tableCommand = @"
                DROP TABLE IF EXISTS DemoPage;
                CREATE TABLE IF NOT EXISTS DEMOPAGE(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name NVARCHAR(2048) NULL,
                    Ext VARCHAR(10) NULL,
                    LocalExt VARCHAR(10) NULL,
                    LocalMirrorFile INTEGER
                );

                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '1A',
                    '.jpg',
                    '',
                    1
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '2B',
                    '',
                    '.png',
                    0
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '3B',
                    '.jpg',
                    '.png',
                    0
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '4A',
                    '.jpg',
                    '.gif',
                    0
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '5C',
                    '',
                    '',
                    1
                  );
                ";

        var createTable = new SqliteCommand(tableCommand, db);

        createTable.ExecuteReader();
    }
}