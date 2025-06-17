

namespace Sadvo.Application.DTOs.Users
{
    public class UsersDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string userName { get; set; }
        public required string password { get; set; }
    }
}
