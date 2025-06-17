

namespace Sadvo.Application.DTOs.AliancePolitical
{
    public class AliancePoliticalDTO
    {
        public int Id { get; set; }
        public required string NamePartyPolitcalSend { get; set; }
        public required string NamePartyPolitcalReceived { get; set; }
        public required bool isActive { get; set; }
    }
}
