using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class Subscription
    {
        public Subscription()
        {
            UserOfSubscriptions = new HashSet<UserOfSubscription>();
        }

        public string Id { get; set; }
        public string RightId { get; set; }
        public string SubscrationTypeId { get; set; }
        public string TermSubscriptionId { get; set; }

        public virtual SubscrationType SubscrationType { get; set; }
        public virtual TermSubscription TermSubscription { get; set; }
        public virtual ICollection<UserOfSubscription> UserOfSubscriptions { get; set; }
    }
}
