using Eventim.ExpensesAPI.Data.ValueObjects;
using Eventim.ExpensesAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventim.ExpensesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesGroupsPeopleController : ControllerBase
    {
        private IExpensesGroupsPeopleRepository _repository;

        public ExpensesGroupsPeopleController(IExpensesGroupsPeopleRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public ActionResult<ExpensesGroupsPeopleVO> Create(ExpensesGroupsPeopleVO vo)
        {
            if (vo == null) { return BadRequest(); }
            try
            {
                var expensesGroupsPeople = _repository.Create(vo);
                return Ok(expensesGroupsPeople);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPeopleInGroup/{id}")]
        public ActionResult<List<ExpensesGroupsPeopleVO>> GetPeopleInGroup(int id)
        {
            var people = _repository.GetPeopleInGroup(id);
            if (people == null) { return NotFound(); }
            return Ok(people);
        }

    }
}
