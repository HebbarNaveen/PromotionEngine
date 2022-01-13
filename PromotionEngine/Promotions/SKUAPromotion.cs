using PromotionEngine.Models;

namespace PromotionEngine.Promotions
{
    public class SKUAPromotion : IPromotion
    {

        public int Id { get; set; }
        public string Name { get; set; }
        IPromotion.PromotionType IPromotion.PromoType { get; set; }

        readonly List<Product> products;
        readonly int promoUnitPrice = 130;

        public SKUAPromotion(List<Product> products)
        {
            Id = 001;
            Name = "NItemsPromotion";
            this.products = products;
        }
        public int ApplyPromotion()
        {
            var productsApplicableForPromo = products.Where(product => product.SKUId == "A").ToList();
            var productsConsideredForPromo = productsApplicableForPromo.Count - productsApplicableForPromo.Count % 3;
            var originalUnitPrice = productsApplicableForPromo.First().UnitPrice;
            var originalPrice = productsApplicableForPromo.Count * originalUnitPrice;
            var discountedPrice = productsConsideredForPromo * promoUnitPrice + (productsApplicableForPromo.Count % 3 * originalUnitPrice);
            return originalPrice - discountedPrice;

        }
    }
}
