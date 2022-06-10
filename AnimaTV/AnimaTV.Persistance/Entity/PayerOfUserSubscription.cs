#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class PayerOfUserSubscription
    {
        public string PayerId { get; set; }
        public string UserOfSubscriptionId { get; set; }

        public virtual Payer Payer { get; set; }
        public virtual UserOfSubscription UserOfSubscription { get; set; }
    }
}
