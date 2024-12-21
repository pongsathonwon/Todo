using Todo.Models;

namespace Todo.Services;

public  static class TodoService
{
    static List<TodoItem> Todos {get;}
    static int nextId = 3;
    static TodoService()
    {
        Todos = new List<TodoItem>
        {
            new TodoItem {Id=0, Name="learning csharp", IsComplete=false},
            new TodoItem {Id=1, Name="learing node js", IsComplete=false}
        };
    }

    public static List<TodoItem> GetAllTodo() => Todos;
    public static TodoItem? Get(int id) => Todos.FirstOrDefault(t => t.Id ==id);

    public static void Add(TodoItem todo)
    {
        todo.Id = nextId++;
        Todos.Add(todo);
    }

    public static void Delete(int id)
    {
        var todo = Get(id);
        if(todo == null)
            return;
        Todos.Remove(todo);
    }

    public static void Update(TodoItem todo)
    {
        var idx = Todos.FindIndex(t => t.Id == todo.Id);
        if(idx < 0)
            return;

        Todos[idx] = todo;
    }
}