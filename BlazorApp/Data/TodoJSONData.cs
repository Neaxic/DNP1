using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public class TodoJSONData : ITodosData
    {
        private string todoFile = "todos.json";
        private IList<Todo> todos;

        public TodoJSONData()
        {
            if (!File.Exists(todoFile))
            {
                Seed();
                string todosAsJson = JsonSerializer.Serialize(todos);
                File.WriteAllText(todoFile, todosAsJson);
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                todos = JsonSerializer.Deserialize<List<Todo>>(content);
            }
        }

        private void Seed()
        {
            Todo[] ts =
            {
                new Todo
                {
                    UserId = 1,
                    TodoId = 1,
                    Title = "Tjen penge",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 2,
                    TodoId = 2,
                    Title = "Scor bitches",
                    IsCompleted = true
                },
            };
            todos = ts.ToList();
        }

        public IList<Todo> GetTodos()
        {
            List<Todo> tmp = new List<Todo>(todos);
            return tmp;
        }

        public void AddTodo(Todo todo)
        {
            int currIndex = todos.Max(todo => todo.TodoId);
            todo.TodoId = (++currIndex);

            todos.Add(todo);
            string todosAsJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(todoFile, todosAsJson);

        }

        public void RemoveTodo(int todoId)
        {
            Todo toRemove = todos.First(t => t.TodoId == todoId);
            todos.Remove(toRemove);
            string todosAsJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(todoFile, todosAsJson);
        }

        public void Update(Todo todo)
        {
            Todo toUpdate = todos.First(t => t.TodoId == todo.TodoId);
            toUpdate.IsCompleted = todo.IsCompleted;
            toUpdate.Title = todo.Title;
            
            string todosAsJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(todoFile, todosAsJson);
        }

        public Todo get(int id)
        {
            return todos.FirstOrDefault(t => t.TodoId == id);
        }
    }
}