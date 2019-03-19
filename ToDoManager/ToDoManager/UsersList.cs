using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManager
{
    class UsersList
    {
        static int lastId = 0;
        Dictionary<int, User> idToUser = null;
        Dictionary<string, User> nameToUser = null;

        UsersList()
        {
            idToUser = new Dictionary<int, User>();
            nameToUser = new Dictionary<string, User>();
        }

        public void add(User user)
        {
            if (user != null)
            {
                if (idToUser[user.Id] == null)
                {
                    idToUser.Add(user.Id, user);
                    nameToUser.Add(user.Name, user);
                }
                else
                {
                    Console.WriteLine("UserList: The username {} is already present in the list!");
                }
            }
        }

        public int getId(User user)
        {
            int id = -1;

            if (user != null)
            {
                id = name
            }
        }
}
