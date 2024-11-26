using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;
using MultiShop.Cargo.DtoLayer.Dtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //IdentityServerUrl appsetting.json da tanýmlandý.
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;//Program.cs de yazdýðýmýz url http olarak yazdýðýmýz için bu ayarý yapmamýz gerekiyor.
});
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);


builder.Services.AddDbContext<CargoContext>();

builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();

builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();

builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();


builder.Services.AddControllers();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
