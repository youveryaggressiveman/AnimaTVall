using System;
using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class UserOfSubscription
    {
        public UserOfSubscription()
        {
            PayerOfUserSubscriptions = new HashSet<PayerOfUserSubscription>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PayerOfUserSubscription> PayerOfUserSubscriptions { get; set; }
    }
}
