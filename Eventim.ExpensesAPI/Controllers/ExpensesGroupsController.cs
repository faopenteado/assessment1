using Eventim.ExpensesAPI.Data.ValueObjects;
using Eventim.ExpensesAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventim.ExpensesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesGroupsController : ControllerBase
    {
        private IExpensesGroupsRepository _repository;

        public ExpensesGroupsController(IExpensesGroupsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public ActionResult<List<ExpensesGroupsVO>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ExpensesGroupsVO> GetById(long id)
        {
            var expensesGroups = _repository.FindById(id);
            if (expensesGroups == null) { return NotFound(); }
            return Ok(expensesGroups);
        }

        [HttpPost]
        public ActionResult<ExpensesGroupsVO> Create(ExpensesGroupsVO vo)
        {
            if (vo == null) { return BadRequest(); }
            var expensesGroups = _repository.Create(vo);
            return Ok(expensesGroups);
        }

        [HttpPut]
        public ActionResult<ExpensesGroupsVO> Update(ExpensesGroupsVO vo)
        {
            if (vo == null) { return BadRequest(); }
            var expensesGroups = _repository.Update(vo);
            return Ok(expensesGroups);
        }
    }
}

