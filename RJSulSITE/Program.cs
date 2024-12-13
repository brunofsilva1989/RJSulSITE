using Microsoft.EntityFrameworkCore;
using RJSulSITE.Data;
using RJSulSITE.Repositories;
using RJSulSITE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurando o contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o de sess�es
builder.Services.AddDistributedMemoryCache(); // Necess�rio para armazenar sess�es na mem�ria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true; // Somente acess�vel via HTTP
    options.Cookie.IsEssential = true; // Essencial para o funcionamento do site
});

// Inje��o de depend�ncia para reposit�rios e servi�os
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITopicoRepository, TopicoRepository>();
builder.Services.AddScoped<ITopicoService, TopicoService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>(); // Adicionando o reposit�rio de Coment�rios
builder.Services.AddScoped<IComentarioService, ComentarioService>();       // Adicionando o servi�o de Coment�rios

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Habilitar middleware de sess�es antes de Authorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
