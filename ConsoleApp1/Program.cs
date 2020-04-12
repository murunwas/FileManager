using FileManager;
using FileManager.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static async  Task Main(string[] args)
        {
            //new AppDemo().TestDate();
            var data = new Manager();

            var files =await  data.GetFilesFromFolderAsync($@"D:\Pics\DCIM");

            foreach (var file in files)
            {
                System.Console.WriteLine($"-----{file}-----------------------------");
            }
        }
    }
}
