namespace Eventim.ExpensesAPI.Data.ValueObjects
{
    public class DebtsVO
    {
        public string PersonToPay { get; set; }
        public string PersonToReceive { get; set; }
        public decimal AmountToPay { get; set; }
    }
}
