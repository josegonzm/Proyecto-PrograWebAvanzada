using Abstracciones.BW;
using Abstracciones.DA;
using Autorizacion.Abstracciones.BW;
using Autorizacion.AutorizacionMiddleware;
using Autorizacion.BW;
using BW;
using DA;
using DA.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}
);

builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();

builder.Services.AddScoped<IProveedorDA, ProveedorDA>();
builder.Services.AddScoped<IProveedorBW, ProveedorBW>();


builder.Services.AddScoped<IProductoDA, ProductoDA>();
builder.Services.AddScoped<IProductoBW, ProductoBW>();

builder.Services.AddScoped<IUsuarioDA, UsuarioDA>();
builder.Services.AddScoped<IUsuarioBW, UsuarioBW>();

builder.Services.AddScoped<ICategoriaDA, CategoriaDA>();
builder.Services.AddScoped<ICategoriaBW, CategoriaBW>();

builder.Services.AddScoped<ICarritoCompraDA, CarritoCompraDA>();
builder.Services.AddScoped<ICarritoCompraBW, CarritoCompraBW>();

builder.Services.AddScoped<IVentasDA, VentasDA>();
builder.Services.AddScoped<IVentasBW, VentasBW>();

builder.Services.AddTransient<IAutorizacionBW, AutorizacionBW>();
builder.Services.AddTransient<Autorizacion.Abstracciones.DA.ISeguridadDA, Autorizacion.DA.SeguridadDA>();
builder.Services.AddTransient<Autorizacion.Abstracciones.DA.IRepositorioDapper, Autorizacion.DA.Repositorio.RepositorioDapperSeguridad>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AutorizacionClaims();
app.UseAuthorization();

app.MapControllers();

app.Run();
