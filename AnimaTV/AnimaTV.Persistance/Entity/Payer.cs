using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class Payer
    {
        public Payer()
        {
            PayerOfUserSubscriptions = new HashSet<PayerOfUserSubscription>();
        }

        public string Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardholderName { get; set; }

        public virtual ICollection<PayerOfUserSubscription> PayerOfUserSubscriptions { get; set; }
    }
}
