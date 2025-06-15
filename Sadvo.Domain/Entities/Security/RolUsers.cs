namespace Sadvo.Domain.Entities.Security
{
    public class RolUsers
    {
        //PK
        public int Id { get; set; }
        //FK
        public int userId { get; set; }
        //FK
        public required string userName { get; set; }
        //FK
        public string? rolName { get; set; }
        public bool isActive { get; set; }

        public ICollection<Roles>? role { get; set; }
        public ICollection<Users>? user { get; set; }
    }
}
