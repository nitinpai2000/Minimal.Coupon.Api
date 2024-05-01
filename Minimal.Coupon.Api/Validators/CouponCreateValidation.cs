using FluentValidation;
using Minimal.Coupon.Api.Data.DTO;

namespace Minimal.Coupon.Api.Validators
{
    public class CouponCreateValidation : AbstractValidator<CouponCreateDTO>
    {
        public CouponCreateValidation() { 
            RuleFor(model => model.Name).NotEmpty();
        }

    }
}
