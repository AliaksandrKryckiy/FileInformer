using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming.Infrastructure
{
    public delegate void OnCreateHandler(ISendingFile attachFilePath);

    public interface IFileWatcher
    {
        void Run(string watchingPath);
        void RegisterHandler(OnCreateHandler del);
        void Dispose();
    }
}
