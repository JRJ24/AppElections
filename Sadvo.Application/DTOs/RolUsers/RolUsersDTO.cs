

namespace Sadvo.Application.DTOs.RolUsers
{
    public class RolUsersDTO
    {    
        public int Id { get; set; }
        public int userId { get; set; }
        public required string userName { get; set; }
        public string? rolName { get; set; }
        public bool isActive { get; set; }
    }
}
