using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=> 
    //policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()//gelen tüm isteklere izin vermiþ oluyoruz olmamasý gerek bir durum
    policy.WithOrigins("http://localhost:4200/", "http://localhost:4200", "https://localhost:4200/", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));

builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())

    //controller gelmeden otomatik olarak kontrol ediyor 
    //.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());

    //validator otomatik iþlemini deve dýþý býrakýyor bu sayede valide controllerlarýn içerisnde kontrol edebiliyoru
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
