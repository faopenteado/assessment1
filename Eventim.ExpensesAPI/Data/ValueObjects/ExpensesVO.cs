using Eventim.Expenses.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eventim.ExpensesAPI.Data.ValueObjects
{
    public class ExpensesVO
    {
        public long ExpensesGroupPeopleId { get; set; }
        public long ExpensesGroupsId { get; set; }
        public string PeopleName { get; set; }
        public string ExpensesGroupsName { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
