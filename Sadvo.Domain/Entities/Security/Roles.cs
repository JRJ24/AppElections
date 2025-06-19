using Sadvo.Domain.BaseCommon;

namespace Sadvo.Domain.Entities.Security
{
    public class Roles : Audit
    {
        public ICollection<RolUsers>? rolUsers { get; set; }
    }
}
