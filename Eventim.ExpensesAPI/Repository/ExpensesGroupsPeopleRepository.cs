using AutoMapper;
using Eventim.Expenses.Model;
using Eventim.Expenses.Model.Context;
using Eventim.ExpensesAPI.Config;
using Eventim.ExpensesAPI.Data.ValueObjects;
using Eventim.ExpensesAPI.Model;
using Eventim.ExpensesAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Eventim.ExpensesAPI.Repository
{
    public class ExpensesGroupsPeopleRepository :IExpensesGroupsPeopleRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public ExpensesGroupsPeopleRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public ExpensesGroupsPeopleVO Create(ExpensesGroupsPeopleVO vo)
        {
            ExpensesGroupsPeople expensesGroupsPeople = ComplexObjectMappingConfig.MapExpensesGroupsPeopleVO(vo, _context);
            
           _context._ExpensesGroupsPeople.Add(expensesGroupsPeople);
            _context.SaveChanges();
            return ComplexObjectMappingConfig.MapExpensesGroupsPeopleVO(expensesGroupsPeople);
        }

        public List<ExpensesGroupsPeopleVO> GetPeopleInGroup(int id)
        {
            var expensesGroupsPeople = _context._ExpensesGroupsPeople.Include(x=> x.ExpensesGroups).Where(x=>  x.ExpensesGroups.Id == id).ToList();

            var ret = new List<ExpensesGroupsPeopleVO>();
            foreach (var e in expensesGroupsPeople)
                ret.Add(ComplexObjectMappingConfig.MapExpensesGroupsPeopleVO(e));

            return ret;

        }
    }
}
