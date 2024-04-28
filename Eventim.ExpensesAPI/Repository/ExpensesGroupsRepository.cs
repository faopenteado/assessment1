using AutoMapper;
using Eventim.Expenses.Model.Context;
using Eventim.Expenses.Model;
using Eventim.ExpensesAPI.Data.ValueObjects;
using Eventim.ExpensesAPI.Repository.Interfaces;

namespace Eventim.ExpensesAPI.Repository
{
    public class ExpensesGroupsRepository : IExpensesGroupsRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        
        public ExpensesGroupsRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ExpensesGroupsVO> GetAll()
        {
            return _mapper.Map<List<ExpensesGroupsVO>>(_context._ExpensesGroups.ToList());
        }


        public ExpensesGroupsVO Create(ExpensesGroupsVO vo)
        {
            ExpensesGroups expensesGroups = _mapper.Map<ExpensesGroups>(vo);
            _context._ExpensesGroups.Add(expensesGroups);
            _context.SaveChanges();
            return _mapper.Map<ExpensesGroupsVO>(expensesGroups);
        }

        public ExpensesGroupsVO FindById(long id)
        {
            ExpensesGroups? expensesGroups = _context._ExpensesGroups.Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<ExpensesGroupsVO>(expensesGroups);
        }

        public ExpensesGroupsVO Update(ExpensesGroupsVO vo)
        {
            ExpensesGroups expensesGroups = _mapper.Map<ExpensesGroups>(vo);
            _context._ExpensesGroups.Update(expensesGroups);
            _context.SaveChanges();
            return _mapper.Map<ExpensesGroupsVO>(expensesGroups);
        }
    }
}
