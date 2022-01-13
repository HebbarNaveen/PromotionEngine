namespace PromotionEngine.Promotions
{
    public interface IPromotion
    {
        int Id { get;  set; }
        string Name { get;  set; }
        PromotionType PromoType { get;  set; }
        enum PromotionType
        {
            NItems,
            Combination
        }

        int ApplyPromotion();
    }
}
