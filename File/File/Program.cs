using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);

            Console.WriteLine(systemPath);

            MyFile myFile = ReadFolderInfo(string path);




            Console.ReadKey();
        }

        static bool IsDirectory(FileInfo fi)
        {
            return ((fi.Attributes & FileAttributes.Directory) ==
                FileAttributes.Directory);
        }

        static MyFile ReadFolderInfo(string path)
        {
            MyFile myFile;

            FileInfo fi = new FileInfo(path);

            if (IsDirectory(fi))
            {
                myFile = new Folder(path);

                DirectoryInfo di = new DirectoryInfo(path);

                try
                {
                    foreach (var fi in di.EnumerateDirectories())
                    {
                        file.
                        Console.WriteLine($"{fi.Name} {fi.Length}");
                    }

                    foreach (var fi in di.EnumerateFiles())
                    {
                        Console.WriteLine($"{fi.Name} {fi.Length}");
                    }
                }
                catch (UnauthorizedAccessException unAuth)
                {
                    Console.WriteLine($"{unAuth.Message}");
                }
            }


            return file;
        }
    }

    class MyFile
    {
        string Name { get; set; }

        public MyFile(string name)
        {
            Name = name;
        }

        public virtual int Size()
        {
            return 0;
        }
    }

    class Folder : MyFile
    {
        List<MyFile> files;

        public Folder(string name) : base(name)
        {

        } 

        public override int Size()
        {
            int size = 0;

            return size;
        }
    }

    class ContentFile : MyFile
    {
        public int Size { get; set; }

        public ContentFile(string name) : base(name)
        {

        }
    }
}
