using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Minimal.Coupon.Api;
using Minimal.Coupon.Api.Data;
using Minimal.Coupon.Api.Data.DTO;
using Minimal.Coupon.Api.Validators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Minimal.Coupon.Api.MapperConfig));
builder.Services.AddValidatorsFromAssemblyContaining<CouponCreateValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/api/coupon", (ILogger<Program> logger) =>
{
    logger.Log(LogLevel.Information, "Get All Coupons Called");
    return CouponRepository.GetAll();
}).WithName("GetAllCoupons");

app.MapGet("/api/coupon/{id:int}", (int id) =>
{
    return CouponRepository.GetAll().FirstOrDefault(x => x.Id == id);
}).WithName("GetCoupon");

app.MapPost("/api/coupon", (IMapper mapper,IValidator<CouponCreateDTO> couponCreationValidation, [FromBody] CouponCreateDTO coupon_create_dto) =>
{
    if(!couponCreationValidation.Validate(coupon_create_dto).IsValid)
    {
        return Results.BadRequest(coupon_create_dto);
    }
    
    var id = CouponRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

    var coupon = mapper.Map<Coupon>(coupon_create_dto);
    coupon.Id = id;   

    CouponRepository.Coupons.Add(coupon);

    return Results.CreatedAtRoute("GetCoupon", new { id = id }, mapper.Map<CouponDTO>(coupon));
}).WithName("CreateCoupon").Accepts<CouponCreateDTO>("application/json").Produces<CouponDTO>().Produces(400);

app.Run();


