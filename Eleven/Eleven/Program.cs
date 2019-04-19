using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleven
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FriendshipEntity> fe = CreateFEMockUp();
            List<PersonEntity> pe = CreatePEMockUp();


            IEnumerable<Person> people = pe
                                .Select(p => new Person
                                {
                                    Id = p.Id,
                                    FullName = p.Name,
                                    
                                });

            var l1 = fe.Select(f => new
            {
                f.FriendId1,
                f.FriendId2,
            })
            .Join(people, f => f.FriendId1, p => p.Id, (f, p) => new { f1 = f.FriendId2, f2 = p })
            .Join(people, x1 => x1.f1, p => p.Id,
            (p, x2) => new { p1 = p, p2 = x2 }).GroupBy(p => p);           

            IEnumerable<Person> result = 

            var groupedById1 = pe
                                .Join(fe, p => p.Id, f => f.FriendId2, (p, f) => new
                                {
                                    Id = p.Id,
                                    FullName = p.Name,
                                    Fs = f.FriendId2
                                })
                                .GroupBy(f => new f)

                    .GroupBy(f => f.FriendId1)
                    .Join(pe, f => f.Key, 




            //var result = pe.Join(fe, p => p.Id, f => f.FriendId1,
            //                     (p, f) => new Person
            //                     {
            //                         Id = p.Id;

            //                     });

        }

        static List<FriendshipEntity> CreateFEMockUp()
        {
            return new List<FriendshipEntity>
            {
                new FriendshipEntity{ Id = 0, FriendId1 = 0, FriendId2 = 1},
                new FriendshipEntity{ Id = 1, FriendId1 = 0, FriendId2 = 2},
                new FriendshipEntity{ Id = 2, FriendId1 = 1, FriendId2 = 2},
                new FriendshipEntity{ Id = 3, FriendId1 = 1, FriendId2 = 0},
                new FriendshipEntity{ Id = 4, FriendId1 = 2, FriendId2 = 0},
                new FriendshipEntity{ Id = 5, FriendId1 = 2, FriendId2 = 1},
                new FriendshipEntity{ Id = 6, FriendId1 = 6, FriendId2 = 7},
                new FriendshipEntity{ Id = 7, FriendId1 = 7, FriendId2 = 6},

            };
        }
        static List<PersonEntity> CreatePEMockUp()
        {
            return new List<PersonEntity>
            {
                new PersonEntity{ Id = 0, Name = "Dario"},
                new PersonEntity{ Id = 1, Name = "Antonio"},
                new PersonEntity{ Id = 2, Name = "Gerardo"},
                new PersonEntity{ Id = 3, Name = "Ciccio"},
                new PersonEntity{ Id = 4, Name = "Giorgio"},
                new PersonEntity{ Id = 5, Name = "Felice"},
                new PersonEntity{ Id = 6, Name = "Henry"},
                new PersonEntity{ Id = 7, Name = "John"},
            };
        }
    }
}
class FriendshipEntity
{
    public int Id { get; set; }
    public int FriendId1 { get; set; }
    public int FriendId2 { get; set; }
}

class PersonEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<Person> Friends { get; set; }
}


