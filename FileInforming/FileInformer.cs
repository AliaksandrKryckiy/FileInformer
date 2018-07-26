using System;
using System.Collections.Generic;
using System.IO;

namespace FileInforming.Infrastructure
{
    public class FileInformer : IFileInformer, IDisposable
    {
        private IFileWatcherHandler _fileWatcherHandler;
        private IEmailSenderHandler _emailSenderHandler;
        private IFileManager _fileManager;        
        private ISettingManager _settingManager;

        public FileInformer(IFileWatcherHandler fileWatcherHandler, IEmailSenderHandler emailSenderHandler, IFileManager fileManager, ISettingManager settingManager)
        {
            _fileWatcherHandler = fileWatcherHandler;
            _emailSenderHandler = emailSenderHandler;
            _fileManager = fileManager;            
            _settingManager = settingManager;
        }

        public void Run()
        {
            try
            {
                string path = _settingManager.GetParam("watchingpath").ToString();
                
                if (!_fileManager.CheckExistPath(path))
                    path = _fileManager.CreateFolder(path).FullName;
                                
                //методы "обрабатывающие файл"
                OnCreateHandler del1 = _emailSenderHandler.SendWithAttach;
                OnCreateHandler del2 = _fileManager.DeleteFile;
                Delegate _delegate = Delegate.Combine(del1, del2);

                _fileWatcherHandler.Run(path, _delegate as OnCreateHandler);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
        
        public void Dispose()
        {
            _fileWatcherHandler.Dispose();
        }
    }
}
