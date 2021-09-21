using System.Collections.Generic;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface ITodosData
    {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
        void RemoveTodo(int todoId);
        void Update(Todo todo);
        Todo get(int id);
    }
}