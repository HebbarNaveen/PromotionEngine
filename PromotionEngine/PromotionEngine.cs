using PromotionEngine.Models;
using PromotionEngine.Promotions;

namespace PromotionEngine
{
    public class PromotionEngine
    {
        private readonly List<Product> products;
        public PromotionEngine(List<Product> products)
        {
            this.products = products;
        }
        public List<IPromotion> GetActivePromos()
        {
            var promos = new List<IPromotion>();
            promos.Add(new SKUAPromotion(products));
            promos.Add(new SKUBPromotion(products));
            promos.Add(new ComboPromotion(products));
            return promos;

        }

        public int ApplyPromotions(int promotionId)
        {
            int discount = 0;
            var promotion = GetActivePromos().FirstOrDefault(promo => promo.Id == promotionId);
            if (promotion == null)
            {
                Console.WriteLine($"Invalid promo code {promotionId}");
            }
            else
            {
                discount += promotion.ApplyPromotion();
            }
            return discount;
        }
    }
}