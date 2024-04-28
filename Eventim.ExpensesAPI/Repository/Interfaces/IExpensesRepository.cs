using Eventim.ExpensesAPI.Data.ValueObjects;

namespace Eventim.ExpensesAPI.Repository.Interfaces
{
    public interface IExpensesRepository
    {
        ExpensesVO Create(ExpensesCreationVO expenseVO);
        List<ExpensesVO> GetExpensesByGroupId(long groupId);

        BalanceVO GetExpensesBalanceByGroupId(long groupId);
    }
}
