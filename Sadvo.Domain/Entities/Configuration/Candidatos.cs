using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Elections;

namespace Sadvo.Domain.Entities.Configuration
{
    public class Candidatos : Audit
    {
        public required string lastname { get; set; }
        public required string foto { get; set; }
        public required bool isAssocciate { get; set; }

        public PartyPolitical? partyPolitical { get; set; }
        public ElectivePositions? electivePosition { get; set; }

        public Votes? votes { get; set; }
    }
}
