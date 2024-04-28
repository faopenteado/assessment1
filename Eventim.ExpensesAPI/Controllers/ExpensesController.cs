using Eventim.ExpensesAPI.Data.ValueObjects;
using Eventim.ExpensesAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventim.ExpensesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private IExpensesRepository _repository;

        public ExpensesController(IExpensesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public ActionResult<ExpensesVO> Create(ExpensesCreationVO expensesVO)
        {
            try
            {
                if (expensesVO == null) { return BadRequest(); }
                var expenses = _repository.Create(expensesVO);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetExpensesByGroup/{id}")]
        public ActionResult<List<ExpensesVO>> GetExpensesByGroup(long id)
        {
            try
            {
                if (id < 0) return BadRequest();
                var expenses = _repository.GetExpensesByGroupId(id).OrderByDescending(x=> x.Date);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBalanceByGroup/{id}")]
        public ActionResult<BalanceVO> GetBalanceByGroup(long id)
        {
            try
            {
                if (id < 0) return BadRequest();
                BalanceVO expenses = _repository.GetExpensesBalanceByGroupId(id);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
