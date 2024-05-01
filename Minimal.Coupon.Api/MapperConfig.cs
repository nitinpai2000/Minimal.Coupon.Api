using AutoMapper;
using Minimal.Coupon.Api.Data.DTO;


namespace Minimal.Coupon.Api
{
    public class MapperConfig : Profile
    { 
        public MapperConfig() { 
            CreateMap<Minimal.Coupon.Api.Data.Coupon, CouponCreateDTO>().ReverseMap();
            CreateMap<Minimal.Coupon.Api.Data.Coupon, CouponDTO>().ReverseMap();    
        }
    }
}
