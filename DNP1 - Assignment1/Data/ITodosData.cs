using System.Collections.Generic;
using DNP1___Assignment1.Models;

namespace DNP1___Assignment1.Data
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