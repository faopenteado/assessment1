namespace Eventim.ExpensesAPI.Data.ValueObjects
{
    public class BalanceVO
    {
        public BalanceVO() 
        {
            ExpensesBalance = new List<ExpensesBalanceVO>();
            Debts = new List<DebtsVO>();
        }
        public decimal Total { get; set; }
        public List<ExpensesBalanceVO> ExpensesBalance { get; set; }

        public List<DebtsVO> Debts { get; set; }
    }
}
