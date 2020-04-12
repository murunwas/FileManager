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

        public async Task<string[]> GetFilesFromFolderAsync(FileRequest request)
        {
            if (!await ExistAsync(request.FolderPath))
            {
                throw new ArgumentNullException($"{nameof(request.FolderPath)} does not exist.");
            }
            List<string> filesFound = new List<string>();
            var searchOption = request.IsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in request.Filters)
            {
                filesFound.AddRange(Directory.GetFiles(request.FolderPath, String.Format("*.{0}", filter), searchOption));
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
