using Penalty.Penalty.Classes.RootEntities.Teams;

namespace Penalty.Penalty.PendingPayments
{
    public class PendingPaymentDto
    {
        public string User { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public double BetBalance { get; set; }
        public double DeservedBalance { get; set; }
    }
}