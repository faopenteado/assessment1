using Eventim.Expenses.Model.Context;
using Eventim.ExpensesAPI.Data.ValueObjects;

namespace Eventim.ExpensesAPI.Config
{
    public static class ComplexObjectMappingConfig
    {
        public static ExpensesGroupsPeopleVO MapExpensesGroupsPeopleVO(Model.ExpensesGroupsPeople expensesGroupsPeople)
        {
            return new ExpensesGroupsPeopleVO()
            {
                ExpensesGroupId = expensesGroupsPeople.ExpensesGroups.Id,
                Id = expensesGroupsPeople.Id,
                Name = expensesGroupsPeople.Name,
            };
        }

        public static Model.ExpensesGroupsPeople MapExpensesGroupsPeopleVO(ExpensesGroupsPeopleVO expensesGroupsPeopleVO, SqlContext context)
        {

            var expensesGroup = context._ExpensesGroups.Where(x => x.Id == expensesGroupsPeopleVO.ExpensesGroupId).FirstOrDefault();
            if (expensesGroup == null)
                throw new Exception(TextResources.ErrorMessages.ExpensesGroupsNotFound);
        
            return new Model.ExpensesGroupsPeople
            {
                ExpensesGroups = expensesGroup,
                Name = expensesGroupsPeopleVO.Name,
                Id = expensesGroupsPeopleVO.Id
            };
        }

        public static Expenses.Model.Expenses MapExpensesVO(ExpensesVO expensesVO, SqlContext context)
        {
            var expensesGroup = context._ExpensesGroups.Where(x => x.Id == expensesVO.ExpensesGroupsId).FirstOrDefault();
            if (expensesGroup == null)
                throw new Exception(TextResources.ErrorMessages.ExpensesGroupsNotFound);

            var expensesGroupPeopleId = context._ExpensesGroupsPeople.Where(x => x.Id == expensesVO.ExpensesGroupPeopleId).FirstOrDefault();
            if (expensesGroupPeopleId == null)
                throw new Exception(TextResources.ErrorMessages.PeopleNotFound);

            return new Expenses.Model.Expenses
            {
                Amount = expensesVO.Amount,
                Date = expensesVO.Date,
                Description = expensesVO.Description,
                ExpensesGroups = expensesGroup,
                Id = expensesVO.Id,
                ExpensesGroupsPeople = expensesGroupPeopleId
            };
        }

        public static Expenses.Model.Expenses MapExpensesVO(ExpensesCreationVO expensesCreationVO, SqlContext context)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            var expensesGroup = context._ExpensesGroups.Where(x => x.Id == expensesCreationVO.ExpensesGroupsId).FirstOrDefault();
            if (expensesGroup == null)
                throw new Exception(TextResources.ErrorMessages.ExpensesGroupsNotFound);

            var expensesGroupPeopleId = context._ExpensesGroupsPeople.Where(x => x.Id == expensesCreationVO.ExpensesGroupPeopleId).FirstOrDefault();
            if (expensesGroupPeopleId == null)
                throw new Exception(TextResources.ErrorMessages.PeopleNotFound);

            return new Expenses.Model.Expenses
            {
                Amount = expensesCreationVO.Amount,
                Date = localZone.ToLocalTime(expensesCreationVO.Date),
                Description = expensesCreationVO.Description,
                ExpensesGroups = expensesGroup,
                ExpensesGroupsPeople = expensesGroupPeopleId
            };
        }

        public static ExpensesVO MapExpensesVO(Expenses.Model.Expenses expense)
        {
            return new ExpensesVO
            {
                Amount = expense.Amount,
                Date = expense.Date,
                Description = expense.Description,
                ExpensesGroupsId = expense.ExpensesGroups.Id,
                ExpensesGroupsName = expense.ExpensesGroups.Name,
                Id = expense.Id,
                ExpensesGroupPeopleId = expense.ExpensesGroupsPeople.Id,
                PeopleName = expense.ExpensesGroupsPeople.Name
            };
        }

        public static List<ExpensesVO> MapExpensesVO(List<Expenses.Model.Expenses> expenses)
        {
            var vos = new List<ExpensesVO>();

            foreach(var e in expenses)       
                vos.Add(MapExpensesVO(e));
            
            return vos;
        }
    }
}
