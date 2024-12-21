using Todo.Services;
using Todo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController: ControllerBase
{
    public TodoController()
    {}
    [HttpGet]
    public ActionResult<List<TodoItem>> GetAll() => TodoService.GetAllTodo();

    [HttpGet("{id}")]
    public ActionResult<TodoItem> Get(int id)
    {
        var todo = TodoService.Get(id);

        if(todo == null)
            return NotFound();
        return todo;
    }

    [HttpPost]
    public IActionResult Create(TodoItem todo)
    {
        TodoService.Add(todo);
        return CreatedAtAction(nameof(Get), new {id = todo.Id}, todo);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TodoItem todo)
    {
        if(id != todo.Id)
            return BadRequest();
        
        var currentTodo = TodoService.Get(id);
        if(currentTodo == null)
            return NotFound();

        TodoService.Update(todo);

        return NoContent();
    }
}
