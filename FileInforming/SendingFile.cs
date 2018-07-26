using FileInforming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming
{
    public class SendingFile : ISendingFile
    {
        public string Path { get; set; }
    }
}
