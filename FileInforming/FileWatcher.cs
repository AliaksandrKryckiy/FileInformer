using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using FileInforming.Infrastructure;

namespace FileInforming
{
    public class FileWatcher : IFileWatcher, IDisposable
    {
        private FileSystemWatcher _watcher;                
        private ISendingFile _file;        

        OnCreateHandler _del;

        public FileWatcher(ISendingFile file)
        {            
            _file = file;            
            _watcher = new FileSystemWatcher();
            _watcher.Created += new FileSystemEventHandler(OnCreated);
        }

        public void RegisterHandler(OnCreateHandler del)
        {
            _del = del;
        }
        /// <summary>
        /// Запускает FileWatcher
        /// </summary>
        /// <param name="watchingPath"></param>
        public void Run(string watchingPath)
        {
            try
            {
                _watcher.Path = watchingPath;
            }
            catch (ArgumentException ex)
            {                
                throw ex;
            }
            catch (Exception ex)
            {                
                throw ex;
            }

            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            _watcher.Filter = "*.txt";

            _watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            try
            {
                _file.Path = e.FullPath;
                _del(_file);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _watcher.Created -= new FileSystemEventHandler(OnCreated);
        }
    }
}
