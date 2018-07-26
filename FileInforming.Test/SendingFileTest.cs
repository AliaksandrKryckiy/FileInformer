using FileInforming.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming.Test
{
    [TestFixture]
    public class SendingFileTest
    {
        [Test]
        public void SendingFile_Params_ExpectedPass()
        {
            ISendingFile file = new SendingFile();
            string expected = "somepath";
            file.Path = expected;

            Assert.AreEqual(expected, file.Path);
        }
    }
}
