using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadvo.Application.ViewModels.PoliticalLeader
{
    public class CreatePoliticalLeaderViewModel
    {
        public required int Id { get; set; }
        public required string userName { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public int ElectionID { get; set; }

    }
}
