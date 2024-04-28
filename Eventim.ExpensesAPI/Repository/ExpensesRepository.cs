using AutoMapper;
using Eventim.Expenses.Model;
using Eventim.Expenses.Model.Context;
using Eventim.ExpensesAPI.Config;
using Eventim.ExpensesAPI.Data.ValueObjects;
using Eventim.ExpensesAPI.Model;
using Eventim.ExpensesAPI.Repository.Interfaces;
using Eventim.ExpensesAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace Eventim.ExpensesAPI.Repository
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public ExpensesRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ExpensesVO Create(ExpensesCreationVO expenseVO)
        {
            var expense = ComplexObjectMappingConfig.MapExpensesVO(expenseVO, _context);

            _context._Expenses.Add(expense);
            _context.SaveChanges();
            return ComplexObjectMappingConfig.MapExpensesVO(expense);
        }

        public BalanceVO GetExpensesBalanceByGroupId(long groupId)
        {
            var balance = new BalanceVO();

            var expenses = _context._Expenses.Include(x => x.ExpensesGroups).Include(x => x.ExpensesGroupsPeople).Where(x => x.ExpensesGroups.Id == groupId).ToList();
            var people = _context._ExpensesGroupsPeople.Where(x => x.ExpensesGroups.Id == groupId).ToList();

            if (people.Count > 0 && expenses.Count > 0)
            {                
                balance.ExpensesBalance = GetExpensesBalance(expenses, people);
                balance.Total = expenses.Sum(x => x.Amount);

                balance.Debts = GetExpensesDebts(balance.ExpensesBalance);
                

                return balance;
            }
            return null;
        }


        private List<ExpensesBalanceVO> GetExpensesBalance(List<Expenses.Model.Expenses> expenses, List<ExpensesGroupsPeople> people)
        {
            decimal total = expenses.Sum(x => x.Amount);
            decimal totalPerPerson = total / people.Count;

            var expensesBalance = new List<ExpensesBalanceVO>();
            foreach (var p in people)
            {
                decimal paidByPerson = expenses.Where(x => x.ExpensesGroupsPeople == p).Sum(x => x.Amount);
                expensesBalance.Add(new ExpensesBalanceVO
                {
                    Amount = paidByPerson - totalPerPerson,
                    PersonName = p.Name
                });
            }
            return expensesBalance;
        }


        private List<DebtsVO> GetExpensesDebts(List<ExpensesBalanceVO> balance)
        {
            var whoNeedsToReceive = new List<ExpensesBalanceVO>();

            foreach(var b in balance.Where(x => x.Amount > 0))
            {
                whoNeedsToReceive.Add(new ExpensesBalanceVO
                {
                    Amount = b.Amount,
                    PersonName = b.PersonName
                });
            }
            
            var whoNeedsToPay = new List<ExpensesBalanceVO>() { };
            foreach(var b in balance.Where(x => x.Amount < 0))
            {
                whoNeedsToPay.Add(new ExpensesBalanceVO
                {
                    Amount = b.Amount,
                    PersonName = b.PersonName
                });
            }

            var debts = new List<DebtsVO>();
            foreach (var pay in whoNeedsToPay)
            {
                NestedPayLoop(pay, ref whoNeedsToReceive, ref debts);
            }

            return debts;
        }

        private void NestedPayLoop(ExpensesBalanceVO whoWillPay, ref List<ExpensesBalanceVO> whoNeedsToReceive, ref List<DebtsVO> debts)
        {
            foreach (var whoWillReceive in whoNeedsToReceive)
            {
                if (Math.Abs(whoWillPay.Amount) < whoWillReceive.Amount)
                {
                    whoWillReceive.Amount = whoWillReceive.Amount + whoWillPay.Amount;
                    debts.Add(new DebtsVO
                    {
                        PersonToPay = whoWillPay.PersonName,
                        PersonToReceive = whoWillReceive.PersonName,
                        AmountToPay = Math.Abs(whoWillPay.Amount),
                    });
                    return;
                }
                else
                {
                    whoWillPay.Amount = whoWillPay.Amount + whoWillReceive.Amount;
                    debts.Add(new DebtsVO
                    {
                        PersonToPay = whoWillPay.PersonName,
                        PersonToReceive = whoWillReceive.PersonName,
                        AmountToPay = Math.Abs(whoWillReceive.Amount),
                    });
                }
            }
        }

        public List<ExpensesVO> GetExpensesByGroupId(long groupId)
        {
            var expenses = _context._Expenses.Include(x => x.ExpensesGroups).Include(x => x.ExpensesGroupsPeople).Where(x => x.ExpensesGroups.Id == groupId).ToList();
            return ComplexObjectMappingConfig.MapExpensesVO(expenses);
        }

    }
}
