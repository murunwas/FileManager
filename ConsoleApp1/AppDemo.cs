using FileManager;
using System;

namespace ConsoleApp1
{
    public class AppDemo
    {
        public async void Init()
        {
            Manager manager = new Manager();
            

            //var res = await manager.CreateNewDirAsync("testDir");

            var drives = await manager.GetLogicalDriveAsync();

            //Console.WriteLine($"is created: {res}");
            //Console.WriteLine($"current Dir: {curr}");
            //Console.WriteLine($"current Dir: {await manager.DeleteDirAsync("dddd")}");
            foreach (string drive in drives)
            {
                if (drive=="E:\\") return;
                Console.WriteLine($"====================={drive}==========================");
                var dirs = await manager.GetDirectoriesAsync(drive);
                foreach (var item in dirs)
                {
                    Console.WriteLine($"{item}");
                }
                
            }

            Console.ReadLine();
        }
    }
}
