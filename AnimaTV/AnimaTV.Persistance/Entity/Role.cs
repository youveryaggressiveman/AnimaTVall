using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
