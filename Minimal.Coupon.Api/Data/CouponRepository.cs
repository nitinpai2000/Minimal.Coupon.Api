namespace Minimal.Coupon.Api.Data
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class CouponRepository
    {
        public static List<Coupon> Coupons { get; set; } =
            [
                new Coupon { Id = 1,Name="Coupon1", Description="Coupon 1 description"},
                new Coupon { Id = 2,Name = "Coupon2", Description="Coupon 2 description" },
                new Coupon { Id = 3, Name= "Coupon3", Description="Coupon 3 description"}
            ];
        public static List<Coupon> GetAll()
        {
            return Coupons;
         }
    }
}
