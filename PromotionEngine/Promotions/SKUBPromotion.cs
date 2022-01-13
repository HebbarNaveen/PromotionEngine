using PromotionEngine.Models;

namespace PromotionEngine.Promotions
{
    public class SKUBPromotion : IPromotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        IPromotion.PromotionType IPromotion.PromoType { get; set; }

        readonly List<Product> products;
        readonly int promoUnitPrice = 45;

        public SKUBPromotion(List<Product> products)
        {
            Id = 002;
            Name = "NItemsPromotion";
            this.products = products;
        }
        public int ApplyPromotion()
        {
            var productsApplicableForPromo = products.Where(product => product.SKUId == "B").ToList();
            var productsConsideredForPromo = productsApplicableForPromo.Count - productsApplicableForPromo.Count % 2;
            var originalUnitPrice = productsApplicableForPromo.First().UnitPrice;
            var originalPrice = productsApplicableForPromo.Count * originalUnitPrice;
            var discountedPrice = productsConsideredForPromo * promoUnitPrice + (productsApplicableForPromo.Count % 2 * originalUnitPrice);
            return originalPrice - discountedPrice;

        }
    }
}
