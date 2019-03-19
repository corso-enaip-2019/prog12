using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManager
{
    class ToDo
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public bool Complete { set; get; }
        public int UserId { set; get; }

        public ToDo ()
        {
            Id = -1;
            Description = null;
            Complete = false;
            UserId = -1;
        }

        public ToDo(string description, int userId): base()
        {
            Description = description;
            UserId = userId;
        }
    }
}
