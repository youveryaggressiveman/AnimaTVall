#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class UserOfVideo
    {
        public string UserId { get; set; }
        public string VideoId { get; set; }

        public virtual User User { get; set; }
        public virtual Video Video { get; set; }
    }
}
