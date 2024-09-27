using LigaHowden.Extensions;
using LigaHowden.Requests.ApiRequests;
using LigaHowden.Responses.DomainResponses;
using LigaHowden.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;

namespace LigaHowden
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthenticationCore();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddHttpClient("LigaHowdenClient", client =>
            {
                client.BaseAddress = new Uri("https://api.ligas.edsonluizcandido.com.br/");
            });
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<LeagueService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<UserServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            //Criar um metodo no league service para adicionar uma liga
            //using (var scope = app.Services.CreateScope())
            //{
            //    var scopeServices = scope.ServiceProvider;
            //    var leagueService = scopeServices.GetRequiredService<LeagueService>();
            //    var auth = scopeServices.GetRequiredService<AuthService>();
            //    LoginResponse loginResponse =  await auth.Login(new LoginRequest { Identity = "edinho", Password = "12qw!@QW" });
            //    var user = await auth.User();
            //    LeagueCreateRequest leagueCreateRequest = new LeagueCreateRequest { Name = "Liga Rai ni quem?", Owner = user.Id };
            //    leagueCreateRequest.Slug = leagueCreateRequest.Name.Slugify();
            //    var newLeague = await leagueService.CreateLeague(leagueCreateRequest);
            //    var deleteLeate = await leagueService.DeleteLeague(newLeague.Id);
            //    var leagues = await leagueService.GetLeaguesList();
            //}


            app.Run();
        }
    }
}
