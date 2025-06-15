using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.ElectionsVotes;


namespace Sadvo.Domain.Entities.Configuration
{
    public class PartyPolitical : Audit
    {
        public required string siglasPartyPolitical { get; set; }

        public PoliticalLeader? leader { get; set; }
        public ICollection<AliancePolitical>? aliancePolitical { get; set; }
        public Election? election { get; set; }
        public Votes? votes { get; set; }  
    }
}
