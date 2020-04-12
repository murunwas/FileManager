using FileManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManager.Interfaces
{
    public interface IManager
    {
        Task<bool> CreateNewDirAsync(string path);
        Task<string> GetCurrentDirAsync();
        Task<bool> DeleteDirAsync(string path);
        Task<bool> ExistAsync(string path);
        Task<string[]> GetLogicalDriveAsync();

        Task<string[]> GetDirectoriesAsync(string path);

        Task<string[]> GetFilesAsync(string path);

        Task<string[]> GetFilesFromFolderAsync(FileRequest request);





    }
}
