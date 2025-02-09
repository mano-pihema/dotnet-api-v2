using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todos2.Interfaces;
using todos2.Models;

namespace todos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosRepository _todosRepository;

        public TodosController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
        {
            var todos = await _todosRepository.GetTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Todo>> GetById([FromRoute] int id)
        {
            var todo = await _todosRepository.GetTodoByIdAsync(id);
            // if (todo == null)
            // {
            //     return NotFound();
            // }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Create([FromBody] CreateTodo todo)
        {
            var newTodo = await _todosRepository.CreateTodoAsync(todo);
            return CreatedAtAction(nameof(GetById), new { id = newTodo.Id }, newTodo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Todo>> Update(
            [FromBody] UpdateTodo update,
            [FromRoute] int id
        )
        {
            var updatedTodo = await _todosRepository.UpdateTodoAsync(id, update);
            if (updatedTodo == null)
            {
                return NotFound();
            }
            return Ok(updatedTodo);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var todo = await _todosRepository.DeleteTodoAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
