using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming.Infrastructure
{
    public interface IFileWatcherHandler
    {
        void Run(string path, OnCreateHandler del);
        void Dispose();
    }
}
