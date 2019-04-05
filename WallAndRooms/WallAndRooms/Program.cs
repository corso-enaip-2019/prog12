using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallAndRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> home = CreateMockRooms();

            PrintHome(home);
        }

        static void PrintHome(List<Room> home)
        {
            double homeSurface = 0.0;

            foreach (Room room in home)
            {
                Console.WriteLine(room.Name);
                Console.WriteLine();

                Console.WriteLine("\t{0, 6}", room.Surface());

                homeSurface += room.Surface();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total surface {0, 6}", homeSurface);

            Console.ReadKey();
        }

        static List<Room> CreateMockRooms()
        {
            Room room;
            List<Room> home = new List<Room>();

            room = new Room("Kitchen");
            room.AddWall(new Wall(3.4, 3.0));
            room.AddWall(new Wall(4.0, 3.0));
            room.AddWall(new Wall(3.4, 3.0));
            room.AddWall(new Wall(3.4, 3.0));

            home.Add(room);

            room = new Room("Living room");
            room.AddWall(new Wall(5.0, 3.0));
            room.AddWall(new Wall(6.0, 3.0));
            room.AddWall(new Wall(5.0, 3.0));
            room.AddWall(new Wall(6.0, 3.0));

            home.Add(room);

            room = new Room("Bathroom");
            room.AddWall(new Wall(4.0, 3.0));
            room.AddWall(new Wall(2.5, 3.0));
            room.AddWall(new Wall(4.0, 3.0));
            room.AddWall(new Wall(2.5, 3.0));

            home.Add(room);

            return home;
        }

    }

    class Wall
    {
        double Length { get; }
        double Height { get; }

        public Wall (double length, double height)
        {
            Length = length;
            Height = height;
        }

        public double Surface()
        {
            return Length * Height;
        }
    }

    class Room
    {
        public string Name { set; get; }

        List<Wall> Walls;


        public Room (string name)
        {
            Name = name;
            Walls = new List<Wall>();
        }

        public List<Wall> GetWalls()
        {
            return Walls;
        }

        public void AddWall(Wall wall)
        {
            if (Walls.Count < 4)
            {
                Walls.Add(wall);
            }
            else
            {
                Console.WriteLine("Error: The room contains already 4 walls!");
            }

            return;
        }

        public double Surface()
        {
            double surface = 0.0;

            foreach (Wall wall in Walls)
            {
                surface += wall.Surface();
            }

            return surface;
        }
    }
}
