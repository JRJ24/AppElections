namespace Sadvo.Domain.Entities.Configuration
{
    public class AliancePolitical
    {
        public int Id { get; set; }
        public required string NamePartyPolitcalSend { get; set; }
        public required string NamePartyPolitcalReceived { get; set; }
        public required bool isActive { get; set; }

        public ICollection<PartyPolitical>? Politicals { get; set; }

    }
}
