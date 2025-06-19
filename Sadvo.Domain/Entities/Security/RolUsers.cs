namespace Sadvo.Domain.Entities.Security
{
    public class RolUsers
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int rolID { get; set; }
        public bool isActive { get; set; }

        public Roles? role { get; set; }
        public Users? user { get; set; }
    }
}
