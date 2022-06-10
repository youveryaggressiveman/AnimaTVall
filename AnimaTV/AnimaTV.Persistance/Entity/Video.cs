using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class Video
    {
        public Video()
        {
            UserOfVideos = new HashSet<UserOfVideo>();
        }

        public string Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<UserOfVideo> UserOfVideos { get; set; }
    }
}
