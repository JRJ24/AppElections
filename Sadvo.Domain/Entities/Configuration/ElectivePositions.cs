using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.ElectionsVotes;


namespace Sadvo.Domain.Entities.Configuration
{
    public class ElectivePositions : Audit
    {
        public int ElectionID { get; set; }

        public ICollection<Candidatos>? Candidatos { get; set; }

        public Election? election { get; set; }
  
    }
}
