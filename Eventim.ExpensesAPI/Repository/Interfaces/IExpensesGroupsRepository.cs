using Eventim.ExpensesAPI.Data.ValueObjects;

namespace Eventim.ExpensesAPI.Repository.Interfaces
{
    public interface IExpensesGroupsRepository
    {
        List<ExpensesGroupsVO> GetAll();
        ExpensesGroupsVO  FindById(long id);
        ExpensesGroupsVO Create(ExpensesGroupsVO vo);
        ExpensesGroupsVO Update(ExpensesGroupsVO vo);
    }
}
