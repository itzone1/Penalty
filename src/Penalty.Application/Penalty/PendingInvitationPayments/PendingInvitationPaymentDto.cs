namespace Penalty.Penalty.PendingInvitationPayments
{
    internal class PendingInvitationPaymentDto
    {
        public PendingInvitationPaymentDto()
        {
        }

        public string User { get; set; }
        public int InvitationsCount { get; set; }
        public double DeservedBalance { get; set; }
    }
}