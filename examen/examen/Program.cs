using examen.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

//imprementamos para el us de las apis
using examen.Services.Contrato;
using examen.Services.Implementacion;
using AutoMapper;
using examen.DTOs;
using examen.Uitilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//obtenemos la conexion al al bd
builder.Services.AddDbContext<TrabajadoresPruebaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQl"));
});

//implementar -----------,,
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IDistritoService, DistritoService>();
builder.Services.AddScoped<ITrabajadoresService, TrabajadorService>();
builder.Services.AddAutoMapper(typeof(AutoMaper));

//configuracion que las apis funcione en cualqier navegador
builder.Services.AddCors(options => {
    options.AddPolicy("Apis", app =>
    {
        app.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//fin--------------,,

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region API DE DISTRITO
//peticiones apis Distrito
app.MapGet("/distrito/lista", async (
  IDistritoService _distritoService,
  IMapper _mapper
  ) =>
{
    var listadistrito = await _distritoService.GetList();
    var listadistritoDTO = _mapper.Map<List<DistritoDTO>>(listadistrito);

    if (listadistritoDTO.Count > 0)
        return Results.Ok(listadistritoDTO);
    else
        return Results.NotFound();
});//fin

app.MapPost("/distrito/guardar", async (
  DistritoDTO modelo,
  IDistritoService _distritoService,
  IMapper _mapper
  ) =>
{
    var _distrito = _mapper.Map<Distrito>(modelo);
    var _distritoCread = await _distritoService.Add(_distrito);

    if (_distritoCread.Id != 0)
        return Results.Ok(_mapper.Map<DistritoDTO>(_distritoCread));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapPut("/distrito/actualizar/{idDis}", async (
  int idDis,
  DistritoDTO modelo,
  IDistritoService _distritoService,
  IMapper _mapper
  ) =>
{
    var _encontrado = await _distritoService.Get(idDis);

    if (_encontrado is null)
        return Results.NotFound();

    var _trabajado = _mapper.Map<Distrito>(modelo);

    _encontrado.NombreDistrito = _trabajado.NombreDistrito;

    var respusta = await _distritoService.Update(_encontrado);

    if (respusta)
        return Results.Ok(_mapper.Map<DistritoDTO>(_encontrado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapDelete("/distrito/eliminar/{idDis}", async (
  int idDis,
  IDistritoService _distritoService
  ) =>
{
    var _encontrado = await _distritoService.Get(idDis);

    if (_encontrado is null)
        return Results.NotFound();

    var respusta = await _distritoService.Delete(_encontrado);

    if (respusta)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

#endregion

#region API DE PROVINCIA
//peticiones apis provincia
app.MapGet("/provincia/lista", async (
  IProvinciaService _provinciaService,
  IMapper _mapper
  ) =>
{
    var listaprovincia = await _provinciaService.GetList();
    var listaprovinciaDTO = _mapper.Map<List<ProvinciaDTO>>(listaprovincia);

    if (listaprovinciaDTO.Count > 0)
        return Results.Ok(listaprovinciaDTO);
    else
        return Results.NotFound();
});//fin


app.MapPost("/provincia/guardar", async (
  ProvinciaDTO modelo,
  IProvinciaService _provinciaService,
  IMapper _mapper
  ) =>
{
    var _provincia = _mapper.Map<Provincia>(modelo);
    var _provinciaCread = await _provinciaService.Add(_provincia);

    if (_provinciaCread.Id != 0)
        return Results.Ok(_mapper.Map<ProvinciaDTO>(_provinciaCread));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapPut("/provincia/actualizar/{idProv}", async (
  int idProv,
  ProvinciaDTO modelo,
  IProvinciaService _provinciaService,
  IMapper _mapper
  ) =>
{
    var _encontrado = await _provinciaService.Get(idProv);

    if (_encontrado is null)
        return Results.NotFound();

    var _trabajado = _mapper.Map<Provincia>(modelo);

    _encontrado.NombreProvincia = _trabajado.NombreProvincia;

    var respusta = await _provinciaService.Update(_encontrado);

    if (respusta)
        return Results.Ok(_mapper.Map<ProvinciaDTO>(_encontrado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapDelete("/provincia/eliminar/{idProv}", async (
  int idProv,
  IProvinciaService _provinciaService
  ) =>
{
    var _encontrado = await _provinciaService.Get(idProv);

    if (_encontrado is null)
        return Results.NotFound();

    var respusta = await _provinciaService.Delete(_encontrado);

    if (respusta)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

#endregion

#region API DE DEPARTAMENTO
//peticiones apis departamento
app.MapGet("/departamento/lista", async (
  IDepartamentoService _departamentoService,
  IMapper _mapper
  ) =>
{
    var listaDepartamento = await _departamentoService.GetList();
    var listaDepartamentoDTO = _mapper.Map<List<DepartamentoDTO>>(listaDepartamento);

    if (listaDepartamentoDTO.Count > 0)
        return Results.Ok(listaDepartamentoDTO);
    else
        return Results.NotFound();
});//fin

app.MapPost("/departamento/guardar", async (
  DepartamentoDTO modelo,
  IDepartamentoService _departamentoService,
  IMapper _mapper
  ) =>
{
    var _departamento = _mapper.Map<Departamento>(modelo);
    var _departamentoCread = await _departamentoService.Add(_departamento);

    if (_departamentoCread.Id != 0)
        return Results.Ok(_mapper.Map<TrabajadorDTO>(_departamentoCread));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapPut("/departamento/actualizar/{idDepar}", async (
  int idDepar,
  DepartamentoDTO modelo,
  IDepartamentoService _departamentoService,
  IMapper _mapper
  ) =>
{
    var _encontrado = await _departamentoService.Get(idDepar);

    if (_encontrado is null)
        return Results.NotFound();

    var _trabajado = _mapper.Map<Departamento>(modelo);

    _encontrado.NombreDepartamento = _trabajado.NombreDepartamento;

    var respusta = await _departamentoService.Update(_encontrado);

    if (respusta)
        return Results.Ok(_mapper.Map<DepartamentoDTO>(_encontrado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapDelete("/departamento/eliminar/{idDepar}", async (
  int idDepar,
  IDepartamentoService _departamentoService
  ) =>
{
    var _encontrado = await _departamentoService.Get(idDepar);

    if (_encontrado is null)
        return Results.NotFound();

    var respusta = await _departamentoService.Delete(_encontrado);

    if (respusta)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

# endregion

#region APIS DE TRABAJADOR
//peticiones apis trabajo
app.MapGet("/trabajador/lista", async (
  ITrabajadoresService _trabajadoresService,
  IMapper _mapper
  ) =>
{
    var listaTrabajador = await _trabajadoresService.GetList();
    var listaTrabajadorDTO = _mapper.Map<List<TrabajadorDTO>>(listaTrabajador);

    if (listaTrabajadorDTO.Count > 0)
        return Results.Ok(listaTrabajadorDTO);
    else
        return Results.NotFound();
});//fin

//api para buscar por id del trabajador 
app.MapGet("/trabajador/buscar/{idTrabajador}", async (
    int idTrabajador,
    ITrabajadoresService _trabajadoService,
    IMapper _mapper
) =>
{
    var trabajadorEncontrado = await _trabajadoService.Get(idTrabajador);

    if (trabajadorEncontrado != null)
    {
        var trabajadorDTO = _mapper.Map<TrabajadorDTO>(trabajadorEncontrado);
        return Results.Ok(trabajadorDTO);
    }
    else
    {
        return Results.NotFound();
    }
});//fin

app.MapPost("/trabajador/guardar", async (
  TrabajadorDTO modelo,
  ITrabajadoresService _trabajadoService,
  IMapper _mapper
  ) =>
{
    var _trabajado = _mapper.Map<Trabajador>(modelo);
    var _trabajadoCread = await _trabajadoService.Add(_trabajado);
    
    if (_trabajadoCread.Id != 0)
        return Results.Ok(_mapper.Map<TrabajadorDTO>(_trabajadoCread));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapPut("/trabajador/actualizar/{idTrabajador}", async (
  int idTrabajador,
  TrabajadorDTO modelo,
  ITrabajadoresService _trabajadoService,
  IMapper _mapper
  ) =>
{
    var _encontrado = await _trabajadoService.Get(idTrabajador);

    if (_encontrado is null)
        return Results.NotFound();

    var _trabajado = _mapper.Map<Trabajador>(modelo);
    
    _encontrado.TipoDocumento = _trabajado.TipoDocumento;
    _encontrado.NumeroDocumento = _trabajado.NumeroDocumento;
    _encontrado.Nombres = _trabajado.Nombres;
    _encontrado.Sexo = _trabajado.Sexo;
    _encontrado.IdDepartamento = _trabajado.IdDepartamento;
    _encontrado.IdProvincia = _trabajado.IdProvincia;
    _encontrado.IdDistrito = _trabajado.IdDistrito;

    var respusta = await _trabajadoService.Update(_encontrado);

    if (respusta)
        return Results.Ok(_mapper.Map<TrabajadorDTO>(_encontrado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

app.MapDelete("/trabajador/eliminar/{idTrabajador}", async (
  int idTrabajador,
  ITrabajadoresService _trabajadorService
  ) =>
{
    var _encontrado = await _trabajadorService.Get(idTrabajador);

    if (_encontrado is null)
        return Results.NotFound();

    var respusta = await _trabajadorService.Delete(_encontrado);

    if (respusta)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});//fin

//..-------.
#endregion

app.UseCors("Apis");//añadir 

app.Run();
