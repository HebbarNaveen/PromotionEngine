using PromotionEngine.Models;

namespace PromotionEngine.Promotions
{
    public class ComboPromotion : IPromotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        IPromotion.PromotionType IPromotion.PromoType { get; set; }

        readonly List<Product> products;
        readonly int promoUnitPrice = 30;

        public ComboPromotion(List<Product> products)
        {
            Id = 003;
            Name = "Combopromotion";
            this.products = products;
        }
        public int ApplyPromotion()
        {
            var skuaProducts = products.Where(product => product.SKUId == "A").ToList();
            var skubProducts = products.Where(product => product.SKUId == "B").ToList();
            var productsConsideredForPromo = Math.Min(skuaProducts.Count, skubProducts.Count);

            var originalUnitPriceSKUA = skuaProducts.First().UnitPrice;
            var originalUnitPriceSKUB = skubProducts.First().UnitPrice;
            var originalPrice = skuaProducts.Count * originalUnitPriceSKUA + skubProducts.Count * originalUnitPriceSKUB;
            var discountedPrice = productsConsideredForPromo * promoUnitPrice + (skuaProducts.Count - productsConsideredForPromo) * originalUnitPriceSKUA + (skubProducts.Count - productsConsideredForPromo) * originalUnitPriceSKUB;
            return originalPrice - discountedPrice;

        }
    }
}
