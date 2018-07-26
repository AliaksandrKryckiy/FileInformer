using System;
using System.IO;

namespace FileInforming.Infrastructure
{
    public class FileManager : IFileManager
    {        
        public FileManager()
        {            
        }

        public bool CheckExistPath(string path)
        {
            return Directory.Exists(path);
        }

        public DirectoryInfo CreateFolder(string path)
        {
            try
            {
                return Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void DeleteFile(ISendingFile file)
        {
            try
            {                
                File.Delete(file.Path);
            }
            catch(Exception ex)
            {                
                throw ex;
            }            
        }
    }
}
