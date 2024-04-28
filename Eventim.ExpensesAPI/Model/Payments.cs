using Eventim.ExpensesAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventim.Expenses.Model
{
    [Table("Payments")]
    public class Payments : Base.BaseEntity
    {
        public int Id_People { get; set; }
        public ExpensesGroupsPeople expensesGroupsPeople { get; set; }
        public int Id_ExpenseGroup { get; set; }
        public ExpensesGroups ExpensesGroups { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
