using FileManager;
using System;
using DateManager;

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

        public void TestDate()
        {
            var date =DateTime.Today;
            var obj =default(Object);
            var ddd = "demo@murunwa.ga";

            Console.WriteLine($"Start-Of-Day : {date.StartOfDay()}");
            Console.WriteLine($"End-Of-Day : {date.EndOfDay()}");

            Console.WriteLine($"First Day Of Week : {date.FirstDayOfWeek()}");
            Console.WriteLine($"Last Day Of Week : {date.LastDayOfWeek()}");

            Console.WriteLine($"First Day Of Month : {date.FirstDayOfMonth()}");
            Console.WriteLine($"Last Day Of Month : {date.LastDayOfMonth()}");

            Console.WriteLine($"First Day Of Year : {date.FirstDayOfYear()}");
            Console.WriteLine($"Last Day Of Year : {date.LastDayOfYear()}");

            Console.WriteLine($"Short Date : {date.ShortDate()}");
            Console.WriteLine($"Long Date : {date.LongDate()}");

            Console.WriteLine($"Is Not Null : {obj.IsNotNull()}");
            Console.WriteLine($"Is Valid Email Address : {ddd.IsValidEmailAddress()}");
            var (ss,dd) = ddd.IsDate();
            Console.WriteLine($"is date : {ss}, date : {dd}");
        }
    }
}
