using FileInforming.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming.Test
{
    [TestFixture]
    public class FileWatcherHandlerTest
    {
        [Test]
        public void FileWatcherHandler_Run_ExpectedOnce()
        {
            var fileWatcherMock = new Mock<IFileWatcher>();
            var del = new Mock<OnCreateHandler>();

            fileWatcherMock.Setup(f => f.Run("somepath")).Verifiable();

            var test = new FileWatcherHandler(fileWatcherMock.Object);

            test.Run("somepath", del.Object);

            fileWatcherMock.Verify(f => f.Run("somepath"), Times.Once);
        }

        [Test]
        public void FileWatcherHandler_Dispose_ExpectedOnce()
        {
            var fileWatcherMock = new Mock<IFileWatcher>();
            var del = new Mock<OnCreateHandler>();

            fileWatcherMock.Setup(f => f.Dispose()).Verifiable();

            var test = new FileWatcherHandler(fileWatcherMock.Object);

            test.Dispose();

            fileWatcherMock.Verify(f => f.Dispose(), Times.Once);
        }
    }
}
