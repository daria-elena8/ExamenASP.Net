/*
 
Actorii joaca in mai multe filme, filmele au mai multi actori. 
Se va face o solutie in .net tipul code first + angular impreuna cu 
modelele (tabele) pentru actori, filme si alte informatii necesare. 
In cadrul solutie .net creati endpointurile necesare folisind repositories 
(optional si services) pentru a afisa actorii din baza de date in functie de 
filmele jucate, informatiile doar despre actori, informatiile doar despre filme 
si un endpoint pentru asignarea filmelor la actori. Pentru solutia de frontend 
puteti folosii si react/vue. In cazul angular creati o componenta unde afisati datele 
luate de la backend si o alta componenta pentru asignare. Datele le puteti adauga 
manual in baza cu cod sql nu este necesar endpoint de creare.

 */

using examen.Helpers.Extensions;
using examen.Helpers.Seeders;
using examen.Data;
using examen.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<examenContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// created each time they requested
//builder.Services.AddTransient<IUserRepository, UserRepository>();

//// created once per client request
//builder.Services.AddScoped<IUserRepository, UserRepository>();

//// created on the first req
//builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
//SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<UsersSeeder>();
        service.SeedInitialUsers();
    }
}*/