using FileInforming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming
{
    public class FileWatcherHandler : IFileWatcherHandler, IDisposable
    {
        private IFileWatcher _fileWatcher;        

        public FileWatcherHandler(IFileWatcher fileWatcher)
        {
            _fileWatcher = fileWatcher;            
        }        

        public void Run(string path, OnCreateHandler del)
        {
            try
            {
                _fileWatcher.RegisterHandler(del);
                _fileWatcher.Run(path);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
