namespace Eventim.ExpensesAPI.Data.ValueObjects
{
    public class ExpensesCreationVO
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public long ExpensesGroupPeopleId { get; set; }
        public long ExpensesGroupsId { get; set; }
    }
}
