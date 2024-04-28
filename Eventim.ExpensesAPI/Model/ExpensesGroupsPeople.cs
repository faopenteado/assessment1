using Eventim.Expenses.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eventim.ExpensesAPI.Model
{
    public class ExpensesGroupsPeople : Expenses.Model.Base.BaseEntity
    {
        [Column("Name")]
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public ExpensesGroups ExpensesGroups { get; set; }
    }
}
