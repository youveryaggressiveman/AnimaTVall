using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class TermSubscription
    {
        public TermSubscription()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public string Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
