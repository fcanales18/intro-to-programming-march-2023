// See https://aka.ms/new-console-template for more information
using Marten;
using Status;
using System.Xml.Xsl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    //Promiscuous Mode" - take anything from anyone.
    options.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
    });
});

//we configure "services" - Entities, Values, Services
var connectionString = "host=localhost;database=status_dev;username=postgres;password=TokyoJoe138!;port=5432";
builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
    }
});

var app = builder.Build();

app.UseCors();

app.MapGet("/status", async (IDocumentSession db) =>
{
    var response = await db.Query<StatusMessage>()
    .OrderByDescending(sm => sm.When)
    .FirstOrDefaultAsync();

    if (response == null)
    {
        return Results.Ok(new StatusMessage(Guid.NewGuid(), "No Status to Report", DateTimeOffset.Now));
    }
    else
    {
        return Results.Ok(response);
    }
});

app.MapPost("/status", async (StatusChangeRequest request, IDocumentSession db) =>
{
    //save this in the database
    var messageToSave = new StatusMessage(Guid.NewGuid(), request.Message, DateTimeOffset.Now);
    db.Store<StatusMessage>(messageToSave); //Here's the list of work to do
    await db.SaveChangesAsync(); //do it! save to db
    return Results.Ok(messageToSave);
});

app.Run();//Block

/*
 * app.MapGet("/status", (IDocumentSession db) =>
{
    //get the data from a database
    var statusMessage = new StatusMessage(Guid.NewGuid(), "Looks Good", DateTimeOffset.Now);
    return Results.Ok(statusMessage);
});
*/