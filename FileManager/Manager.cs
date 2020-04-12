using FileManager.Interfaces;
using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileManager
{
    public class Manager : IManager
    {
        public string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public async Task<bool> CreateNewDirAsync(string path)
        {
			try
			{
                if (Directory.Exists(path))
                {
                    throw new Exception($"{path}{Constants.ALREADYEXIST}");
                }
                DirectoryInfo di = Directory.CreateDirectory(path);

                if (Directory.Exists(path))
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<bool> DeleteDirAsync(string path)
        {
            if (await ExistAsync(path))
            {
                Directory.Delete(path);
                return await Task.FromResult(true);
            }
            throw new Exception($"Directory ({path}) you trying to delete {Constants.DOESNOTEXIST}");
        }

        public async Task<bool> ExistAsync(string path)
        {
            return await Task.FromResult(Directory.Exists(path));
        }

        public async Task<string> GetCurrentDirAsync()
        {
            var curDir = Directory.GetCurrentDirectory();
            return await Task.FromResult(curDir);
        }

        public async Task<string[]> GetDirectoriesAsync(string path)
        {
            string[] myDirs = Directory.GetDirectories(path);
            return await Task.FromResult(myDirs);
        }

        public async Task<string[]> GetFilesAsync(string path)
        {
            string[] myFiles = Directory.GetFiles(path);
            return await Task.FromResult(myFiles);
        }

        public async Task<string[]> GetFilesFromFolderAsync(string path, FileRequest request=null)
        {
            if (!await ExistAsync(path))
            {
                throw new ArgumentNullException($"{nameof(path)} does not exist.");
            }
            if (request==null)
            {
                request = new FileRequest();
            }

            List<string> filesFound = new List<string>();
            var searchOption = request.IsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in request.Filters)
            {
                filesFound.AddRange(Directory.GetFiles(path, String.Format("*.{0}", filter), searchOption));
            }
            return await Task.FromResult(filesFound.ToArray());
        }

        public async Task<string[]> GetLogicalDriveAsync()
        {
            string[] drives = Directory.GetLogicalDrives();

            return await Task.FromResult(drives);
        }
    }
}
