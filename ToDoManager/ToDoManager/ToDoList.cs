using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManager
{
    class ToDoList
    {
        List<ToDo> _toDoList = null;

        public ToDoList()
        {
            _toDoList = new List<ToDo>();
        }

        public bool Add(ToDo toDo)
        {
            bool result = false;

            if (toDo != null)
            {
                toDo.Id = _toDoList.Count;

                _toDoList.Add(toDo);

                result = true;
            }

            return result;
        }

        public bool ModifyDescription(int Id, string description)
        {
            bool result = false;

            if (_toDoList[Id] != null && description != null)
            {
                _toDoList[Id].Description = description;

                result = true;
            }

            return result;
        }

        public bool Complete(int Id)
        {
            bool result = false;

            if (_toDoList[Id] != null)
            {
                _toDoList[Id].Complete = true;

                result = true;
            }

            return result;
        }

        public bool Remove(int Id)
        {
            bool result = false;

            if (_toDoList[Id] != null)
            {
                _toDoList.RemoveAt(Id);

                result = true;
            }

            return result;
        }

        public string ToString(int userId)
        {
            string result = "";
            foreach (ToDo toDo in _toDoList)
            {
                result += $"Id: {toDo.Id} Description: {toDo.Description} Complete: {toDo.Complete}\r\n";
            }

            return result;
        }
    }
}
