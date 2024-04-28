using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Eventim.ExpensesAPI.Model;

namespace Eventim.Expenses.Model
{
    [Table("ExpensesGroups")]
    public class ExpensesGroups :Base.BaseEntity
    {
        [Column("Name")]
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public List<Expenses> expenses { get; set; }
        public List<ExpensesGroupsPeople> expensesGroupsPeople { get; set; }
    }
}

