using Eventim.ExpensesAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventim.Expenses.Model
{
    [Table("Expenses")]
    public class Expenses : Base.BaseEntity
    {

        public ExpensesGroupsPeople ExpensesGroupsPeople { get; set; }
        public ExpensesGroups ExpensesGroups { get; set; }

        [Column("Description")]
        [Required]
        public string Description { get; set; }

        [Column("Amount")]
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Column("Date")]
        [Required]
        public DateTime Date { get; set; }


    }
}
