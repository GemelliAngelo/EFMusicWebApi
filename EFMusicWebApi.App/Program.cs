using Serilog;

namespace MusicWebApi.App
{
    /*
    Creare una web api che gestisce un argomento a vostra scelta (un ristorante, museo, supermercato etc):
    Operazioni CRUD utilizzando sia un Controller ma anche un esempio di implementazione con minimal APIs.
    Tutte le operazioni devono essere eseguite tramite un layer di servizi. Attenzione al ciclo di vita di questi servizi!
    Per quanto riguarda il logging usate la libreria Serilog.
    Usare Swagger per la documentazione API. Quindi bisogna fare il setup a livello di progetto.
    Per ogni tipo di oggetto usiamo anche un minimo di validazione come ad esempio i campi obbligatori
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddSingleton<CommonService>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapSongEndpoints();

            app.Run();
        }
    }
}
