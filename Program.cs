using AutoMapper;
using Microsoft.EntityFrameworkCore;
using teste_desafio.context;
using teste_desafio.domain.entities;
using teste_desafio.repositories;
using teste_desafio.service;
using teste_desafio.viewmodel;

var builder = WebApplication.CreateBuilder(args);
var config = new MapperConfiguration(config => 
{

    config.CreateMap<Aluno,AlunoViewModel>();
    config.CreateMap<AlunoViewModel,Aluno>();
    config.CreateMap<AlunoUpdateViewModel,Aluno>();
    config.CreateMap<Turma,TurmaViewModel>();
    config.CreateMap<TurmaViewModel,Turma>();
    config.CreateMap<MatriculaViewModel,Matricula>();
    config.CreateMap<Matricula,MatriculaViewModel>();
    config.CreateMap<Matricula,MatriculaRelacaoViewModel>();

});

IMapper mapper = config.CreateMapper();

// Add services to the container.
builder.Services.AddDbContext<MatriculaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddScoped<ITurmaRepository,TurmaRepository>();
builder.Services.AddScoped<ITurmaService,TurmaService>();
builder.Services.AddScoped<IAlunoRepository,AlunoRepository>();
builder.Services.AddScoped<IAlunoService,AlunoService>();
builder.Services.AddScoped<IMatriculaRepository,MatriculaRepository>();
builder.Services.AddScoped<IMatriculaService,MatriculaService>();

builder.Services.AddSingleton(mapper);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();
