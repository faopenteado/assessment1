using Eventim.ExpensesAPI.Data.ValueObjects;

namespace Eventim.ExpensesAPI.Repository.Interfaces
{
    public interface IExpensesGroupsPeopleRepository
    {
        ExpensesGroupsPeopleVO Create(ExpensesGroupsPeopleVO vo);
        List<ExpensesGroupsPeopleVO> GetPeopleInGroup(int id);
    }
}
