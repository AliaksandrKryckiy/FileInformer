using System.IO;

namespace FileInforming.Infrastructure
{
    public interface IFileManager
    {
        void DeleteFile(ISendingFile file);
        bool CheckExistPath(string path);
        DirectoryInfo CreateFolder(string path);
    }
}
